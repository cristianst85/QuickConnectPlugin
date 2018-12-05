using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class WinScpArgumentsFormatter : IArgumentsFormatter {

        public String ExecutablePath { get; private set; }

        public WinScpArgumentsFormatter(String winScpPath) {
            this.ExecutablePath = winScpPath;
        }

        public String Format(IHostPwEntry hostPwEntry) {
            PuttyOptions options = null;
            bool success = PuttyOptions.TryParse(hostPwEntry.AdditionalOptions, out options);

            StringBuilder sb = new StringBuilder(String.Format("\"{0}\" scp://{1}", ExecutablePath, hostPwEntry.GetUsername()));

            if (!success || (success && !options.HasKeyFile())) {
                sb.AppendFormat(":\"{0}\"", hostPwEntry.GetPassword());
            }

            sb.AppendFormat("@{0}", hostPwEntry.IPAddress);

            if (success && options.Port.HasValue) {
                sb.AppendFormat(":{0}", options.Port);
            }

            // Starting with version 5.6 a passphrase for the private key file can be provided.
            // See: https://winscp.net/eng/docs/faq_passphrase
            if (success && options.HasKeyFile()) {
                sb.AppendFormat(" -privatekey=\"{0}\" -passphrase=\"{1}\"", options.KeyFilePath, hostPwEntry.GetPassword());
            }

            return sb.ToString();
        }
    }
}
