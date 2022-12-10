using QuickConnectPlugin.Commons;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters
{
    public class WinScpArgumentsFormatter : IArgumentsFormatter
    {
        public string ExecutablePath { get; private set; }

        public WinScpArgumentsFormatter(string winScpPath)
        {
            this.ExecutablePath = winScpPath;
        }

        public string Format(IHostPwEntry hostPwEntry)
        {
            WinScpOptions options = null;
            bool success = WinScpOptions.TryParse(hostPwEntry.AdditionalOptions, out options);

            // Try get the protocol if explicitly set, otherwise default to SCP.
            var protocol = (success && options.Protocol.HasValue ? options.Protocol : WinScp.Protocol.Scp).ToString().ToLowerInvariant();

            var stringBuilder = new StringBuilder(string.Format("\"{0}\" {1}://{2}", ExecutablePath, protocol, hostPwEntry.GetUsername()));

            if (!success || (success && !options.HasKeyFile()))
            {
                // See: https://winscp.net/eng/docs/session_url -> Special Characters
                stringBuilder.AppendFormat(":\"{0}\"", HttpUtilityEx.UrlEncodeUpperCase(hostPwEntry.GetPassword()));
            }

            stringBuilder.AppendFormat("@{0}", hostPwEntry.IPAddress);

            if (success && options.Port.HasValue)
            {
                stringBuilder.AppendFormat(":{0}", options.Port);
            }

            // Starting with version 5.6 a pass-phrase for the private key file can be provided.
            // See: https://winscp.net/eng/docs/faq_passphrase
            if (success && options.HasKeyFile())
            {
                stringBuilder.AppendFormat(" -privatekey=\"{0}\" -passphrase=\"{1}\"", options.KeyFilePath, hostPwEntry.GetPassword());
            }

            return stringBuilder.ToString();
        }
    }
}
