using System;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class RemoteDesktopArgumentsFormatter : IArgumentsFormatter {

        public static readonly String RemoteDesktopClientPath = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");

        public bool FullScreen { get; set; }
        public bool UseConsole { get; set; }
        public bool IsOlderVersion { get; set; }

        public RemoteDesktopArgumentsFormatter(IQuickConnectPluginSettings pluginSettings) {
            _pluginSettings = pluginSettings;
        }

        private IQuickConnectPluginSettings _pluginSettings;

        public string Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();

            var xUseRdpPlus = !string.IsNullOrEmpty(_pluginSettings.RdpPlusPath);
            if (xUseRdpPlus) {
                sb.AppendFormat("\"{0}\"", _pluginSettings.RdpPlusPath);
            } else {
                sb.AppendFormat("\"{0}\"", RemoteDesktopClientPath);
            }

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

            sb.AppendFormat(" /u:\"{0}\"", hostPwEntry.GetUsername());
            sb.AppendFormat(" /p:\"{0}\"", hostPwEntry.GetPassword());

            if (xUseRdpPlus) {
                RdpPlusOptions options;
                if (RdpPlusOptionsParser.TryParse(hostPwEntry.AdditionalOptions, out options)) {
                    if (!string.IsNullOrEmpty(options.RDGateway)) {
                        var extraOptions = "gatewayhostname:s:" + options.RDGateway + ", gatewayusagemethod:i:2, gatewaycredentialssource:i:4, gatewayprofileusagemethod:i:1, gatewaybrokeringtype:i:0";
                        if (options.UseSameCredentials) {
                            extraOptions += ", promptcredentialonce:i:1";
                        }

                        sb.Append(" /o:\"" + extraOptions + "\"");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
