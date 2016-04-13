using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class CmdKeyUnregisterArgumentsFormatter : IArgumentsFormatter {

        public bool IncludePath { get; set; }

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            if (this.IncludePath) {
                sb.AppendFormat("\"{0}\" ", CmdKeyRegisterArgumentsFormatter.CmdKeyPath);
            }
            sb.AppendFormat("/delete:TERMSRV/{0}", hostPwEntry.IPAddress);
            return sb.ToString();
        }
    }
}
