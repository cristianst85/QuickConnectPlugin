using System;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChanger : IPasswordChanger {

        public void ChangePassword(string host, string username, string password, string newPassword) {
            KeyboardInteractiveAuthenticationMethod authMethod = new KeyboardInteractiveAuthenticationMethod(username);
            authMethod.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>((sender, e) => authenticationPrompted(sender, e, password));

            ConnectionInfo connectionInfo = new ConnectionInfo(host, username, authMethod);

            using (SshClient sshclient = new SshClient(connectionInfo)) {
                sshclient.Connect();
                using (var shellStream = sshclient.CreateShellStream("xterm", 80, 24, 800, 600, 1024)) {
                    using (var writer = new StreamWriter(shellStream) { AutoFlush = true }) {
                        writer.WriteLine("sudo passwd");
                        processShellStream(shellStream, "New Password");
                        writer.WriteLine(newPassword);
                        processShellStream(shellStream, "Reenter New Password");
                        writer.WriteLine(newPassword);
                        processShellStream(shellStream, "Password changed.");
                    }
                }
            }
        }

        private void processShellStream(ShellStream shellStream, String expectedString) {
            var res = shellStream.Expect(expectedString, TimeSpan.FromSeconds(2));
            if (res == null) {
                throw new Exception(String.Format("Error changing password. Expected '{0}' string from shell, but got null.", expectedString));
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
