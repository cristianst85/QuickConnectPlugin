using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChanger : ILinuxPasswordChanger {

        public const int DefaultSshPort = 22;
        public const int DefaultTimeout = 4;

        public int? SshPort { get; set; }
        public int Timeout { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        public void ChangePassword(string host, string username, string password, string newPassword) {

            this.Timeout = DefaultTimeout;

            using (var keyboardInteractiveAuthenticationMethod = new KeyboardInteractiveAuthenticationMethod(username)) {
                
                keyboardInteractiveAuthenticationMethod.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>((sender, e) => authenticationPrompted(sender, e, password));

                using (var passwordAuthenticationMethod = new PasswordAuthenticationMethod(username, password)) {

                    int port = DefaultSshPort;

                    if (this.SshPort.HasValue) {
                        port = this.SshPort.Value;
                    }

                    string hostWithoutPort = null;

                    if (host.Contains(":")) {
                        hostWithoutPort = host.Substring(0, host.IndexOf(':'));
                        port = int.Parse(host.Substring(host.IndexOf(':') + 1));
                    }
                    else {
                        hostWithoutPort = host;
                    }

                    ConnectionInfo connectionInfo = new ConnectionInfo(hostWithoutPort, port, username,
                        new AuthenticationMethod[] {  
                            keyboardInteractiveAuthenticationMethod,
                            passwordAuthenticationMethod
                        }
                    );

                    var messages = new Collection<String>(); ;

                    using (var sshClient = new SshClient(connectionInfo)) {
                        sshClient.Connect();
                        using (var shellStream = sshClient.CreateShellStream("xterm", 80, 24, 800, 600, 1024)) {
                            shellStream.DataReceived += new EventHandler<ShellDataEventArgs>((s, e) => {
                                var message = Encoding.UTF8.GetString(e.Data)
                                    .Trim('\n').Trim('\r').Trim().
                                    Replace("\n", " / ").
                                    Replace("\r", String.Empty).TrimEnd(':');
                                // Keep only relevant messages - ignore shell prompt lines.
                                if (!(message.Contains("@") || message.EndsWith("/>") || message.EndsWith("]$") || String.IsNullOrEmpty(message))) {
                                    messages.Add(message);
                                }
                            });
                            using (var writer = new StreamWriter(shellStream) { AutoFlush = true }) {
                                writer.WriteLine("passwd");
                                // Non-root user must enter the current password first.
                                processShellStream(shellStream, @"\(current\) UNIX password", writer, password, true, messages);
                                processShellStream(shellStream, "New password", writer, newPassword, false, messages);
                                processShellStream(shellStream, "Re.*new password", writer, newPassword, false, messages);
                                processShellStream(shellStream, "Password.*(changed|updated)|all authentication tokens updated successfully", null, null, false, messages);
                            }
                        }
                    }
                }
            }
        }

        private void processShellStream(ShellStream shellStream, String expectedRegexPattern, StreamWriter writer, string input, bool isOptional, ICollection<string> messages) {
            bool wasExecuted = false;
            Action<string> action = (x) => {
                if (writer != null && input != null) {
                    writer.WriteLine(input);
                };
                wasExecuted = true;
                messages.Clear();
            };
            var expectAction = new ExpectAction(new Regex(expectedRegexPattern, RegexOptions.IgnoreCase), action);
            shellStream.Expect(TimeSpan.FromSeconds(Timeout), expectAction);
            // Shell output is always null when the action was not executed.
            if (!(isOptional || wasExecuted)) {
                var message = messages.LastOrDefault();
                if (messages.Count > 1) {
                    message = string.Format("{0} / {1}", messages.First(), messages.Last());
                }
                throw new Exception(String.Format("Error changing password. Got '{0}' from shell which didn't match the expected '{1}' regex pattern.", message, expectedRegexPattern));
            }
        }

        private void authenticationPrompted(object sender, AuthenticationPromptEventArgs e, String password) {
            foreach (AuthenticationPrompt prompt in e.Prompts) {
                if (prompt.Request.StartsWith("Password:", StringComparison.InvariantCultureIgnoreCase)) {
                    prompt.Response = password;
                }
            }
        }
    }
}
