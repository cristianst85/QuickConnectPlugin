using System;
using System.IO;
using System.Text.RegularExpressions;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChanger : ILinuxPasswordChanger {

        public static readonly int DefaultSshPort = 22;

        public int? SshPort { get; set; }

        public void ChangePassword(string host, string username, string password, string newPassword) {

            var keyboardInteractiveAuthenticationMethod = new KeyboardInteractiveAuthenticationMethod(username);
            keyboardInteractiveAuthenticationMethod.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>((sender, e) => authenticationPrompted(sender, e, password));

            var passwordAuthenticationMethod = new PasswordAuthenticationMethod(username, password);

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

            using (SshClient sshclient = new SshClient(connectionInfo)) {
                sshclient.Connect();
                using (var shellStream = sshclient.CreateShellStream("xterm", 80, 24, 800, 600, 1024)) {
                    using (var writer = new StreamWriter(shellStream) { AutoFlush = true }) {
                        writer.WriteLine("sudo passwd");
                        processShellStream(shellStream, "New Password");
                        writer.WriteLine(newPassword);
                        processShellStream(shellStream, "Re.*new password");
                        writer.WriteLine(newPassword);
                        processShellStream(shellStream, "Password.*(changed|updated)|all authentication tokens updated successfully");
                    }
                }
            }
        }

        private void processShellStream(ShellStream shellStream, String expectedPattern) {
            var res = shellStream.Expect(new Regex(expectedPattern, RegexOptions.IgnoreCase), TimeSpan.FromSeconds(2));
            if (res == null) {
                throw new Exception(String.Format("Error changing password. Expected '{0}' string/pattern from shell, but got null.", expectedPattern));
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
