using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class CmdKeyUnregisterArgumentsFormatter : IArgumentsFormatter {

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", CmdKeyRegisterArgumentsFormatter.CmdKeyPath);
            sb.AppendFormat(" /delete:TERMSRV/{0}", hostPwEntry.IPAddress);
            return sb.ToString();
        }
    }
}
