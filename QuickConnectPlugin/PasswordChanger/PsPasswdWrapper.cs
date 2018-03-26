using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Text;

namespace QuickConnectPlugin.PasswordChanger {

    public class PsPasswdWrapper {

        public const String SupportedVersion = "1.22";
        public const String PsPasswdProductName = "Sysinternals PsPasswd";
        public const String PsPasswdMD5Checksum = "18592F7B8D0CA68CC90A5511180AF8C0";

        public String Path { get; private set; }

        public bool SuppressLicenseDialog { get; set; }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
        public PsPasswdWrapper(String psPasswdPath) {
            if (!File.Exists(psPasswdPath)) {
                throw new FileNotFoundException("The specified file was not found.");
            }
            if (!IsPsPasswdUtility(psPasswdPath)) {
                throw new Exception("The specified file is not valid.");
            }
            if (!IsSupportedVersion(psPasswdPath)) {
                throw new Exception("This version of PsPasswd.exe is not supported.");
            }
            this.Path = psPasswdPath;
        }

        internal static bool IsSupportedVersion(String psPasswdPath) {
            return SupportedVersion.Equals(FileVersionInfo.GetVersionInfo(psPasswdPath).FileVersion);
        }

        internal static bool IsPsPasswdUtility(String pspasswdPath) {
            return PsPasswdProductName.Equals(FileVersionInfo.GetVersionInfo(pspasswdPath).ProductName);
        }

        internal void ChangePassword(String host, String username, String password, String account, String newPassword) {
            if (String.IsNullOrEmpty(host)) {
                throw new ArgumentException("Host cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(username)) {
                throw new ArgumentException("Username cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(password)) {
                throw new ArgumentException("Password cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(account)) {
                throw new ArgumentException("Account cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(newPassword)) {
                throw new ArgumentException("New password cannot be null or an empty string.");
            }

            String response = this.internalChangePassword(host, username, password, account, newPassword);

            if (response.StartsWith("Error changing password:")) {
                throw new Exception(response.Substring(response.IndexOf(':') + 1).Trim());
            }
        }

        private String internalChangePassword(String host, String username, String password, String account, String newPassword) {
            StringBuilder arguments = new StringBuilder();
            arguments.AppendFormat("\\\\{0} -u \"{1}\" -p \"{2}\" \"{3}\" \"{4}\"", host, username, password, account, newPassword);
            if (this.SuppressLicenseDialog) {
                arguments.Append(" --accepteula");
            }
            using (Process process = new Process()) {
                process.StartInfo.FileName = this.Path;
                process.StartInfo.Arguments = arguments.ToString();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                String[] stdErrorLines = process.StandardError.ReadToEnd().Split('\r');
                String[] stdOutputLines = process.StandardOutput.ReadToEnd().Split('\r');
                foreach (String stdErrorLine in stdErrorLines) {
                    String line = stdErrorLine.Trim('\n');
                    if (line.StartsWith("Error changing password:")) {
                        return String.Format("{0} {1}", line, stdErrorLines[5].Trim('\n'));
                    }
                }
                foreach (String stdOutputLine in stdOutputLines) {
                    String line = stdOutputLine.Trim('\n');
                    if (line.StartsWith("Password for") && line.EndsWith("successfully changed.")) {
                        return line;
                    }
                }
                throw new Exception("An unspecified error has occurred.");
            }
        }
    }
}
