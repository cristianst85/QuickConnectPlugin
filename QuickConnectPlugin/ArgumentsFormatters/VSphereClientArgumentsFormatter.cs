using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class VSphereClientArgumentsFormatter : IArgumentsFormatter {

        public String ExecutablePath { get; private set; }

        public VSphereClientArgumentsFormatter(String vSphereClientPath) {
            this.ExecutablePath = vSphereClientPath;
        }

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", this.ExecutablePath);
            sb.AppendFormat(" -s {0} -u {1} -p {2}",
                hostPwEntry.IPAddress,
                hostPwEntry.GetUsername(),
                hostPwEntry.GetPassword()
            );
            return sb.ToString();
        }
    }
}
