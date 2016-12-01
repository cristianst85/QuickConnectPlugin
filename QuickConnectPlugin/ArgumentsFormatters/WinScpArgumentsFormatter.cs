using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class WinScpArgumentsFormatter : IArgumentsFormatter {

        public String ExecutablePath { get; private set; }

        public WinScpArgumentsFormatter(String winScpPath) {
            this.ExecutablePath = winScpPath;
        }

        public String Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder(String.Format("\"{0}\" scp://{2}:{3}@{1}",
                ExecutablePath,
                hostPwEntry.IPAddress,
                hostPwEntry.GetUsername(),
                hostPwEntry.GetPassword()));

            PuttyOptions options = null;
            bool success = PuttyOptionsParser.TryParse(hostPwEntry.AdditionalOptions, out options);

            if (success && options.Port.HasValue) {
                sb.AppendFormat(":{0}", options.Port);
            }

            return sb.ToString();
        }
    }
}
