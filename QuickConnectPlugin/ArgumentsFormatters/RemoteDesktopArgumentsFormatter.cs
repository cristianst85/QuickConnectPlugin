using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters
{
    public class RemoteDesktopArgumentsFormatter : IArgumentsFormatter
    {
        public static readonly string RemoteDesktopClientPath = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");

        public bool UseFullScreen { get; set; }

        public bool UseConsole { get; set; }

        public bool UseAdmin { get; set; }

        public RemoteDesktopArgumentsFormatter()
        {
        }

        public string Format(IHostPwEntry hostPwEntry)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("\"{0}\"", RemoteDesktopClientPath);
            stringBuilder.AppendFormat(" /v:{0}", hostPwEntry.IPAddress);

            if (UseFullScreen)
            {
                stringBuilder.Append(" /f");
            }

            if (UseConsole)
            {
                stringBuilder.Append(" /console");
            }
            else if (UseAdmin)
            {
                stringBuilder.Append(" /admin");
            }

            return stringBuilder.ToString();
        }
    }
}
