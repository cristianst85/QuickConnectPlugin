using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class RemoteDesktopArgumentsFormatter : IArgumentsFormatter {

        public static readonly String RemoteDesktopClientPath = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");

        public bool FullScreen { get; set; }
        public bool UseConsole { get; set; }
        public bool IsOlderVersion { get; set; }

        public RemoteDesktopArgumentsFormatter() {
        }

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", RemoteDesktopClientPath);
            sb.AppendFormat(" /v:{0}", hostPwEntry.IPAddress);

            if (this.FullScreen) {
                sb.Append(" /f");
            }
            if (this.UseConsole) {
                if (this.IsOlderVersion) {
                    sb.Append(" /console");
                }
                else {
                    sb.Append(" /admin");
                }
            }

            return sb.ToString();
        }
    }
}
