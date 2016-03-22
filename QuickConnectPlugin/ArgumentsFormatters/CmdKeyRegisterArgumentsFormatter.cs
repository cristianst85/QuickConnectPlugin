using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class CmdKeyRegisterArgumentsFormatter : IArgumentsFormatter {

        public static readonly String CmdKeyPath = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", CmdKeyPath);
            sb.AppendFormat(" /generic:TERMSRV/{0} /user:{1} /pass:{2}",
                hostPwEntry.IPAddress,
                hostPwEntry.GetUsername(),
                hostPwEntry.GetPassword()
            );
            return sb.ToString();
        }
    }
}
