using System;

namespace QuickConnectPlugin {

    public static class OSTypeUtils {

        public static OSType GetOSTypeFromString(String operatingSystem) {
            if (String.IsNullOrEmpty(operatingSystem)) {
                return OSType.Unknown;
            }
            else if (operatingSystem.ToLower().Contains("windows")) {
                return OSType.Windows;
            }
            else if (operatingSystem.ToLower().Contains("esxi") || operatingSystem.ToLower().Contains("vcenter")) {
                return OSType.ESXi;
            }
            else if (operatingSystem.ToLower().Contains("linux")) {
                return OSType.Linux;
            }
            else {
                return OSType.Unknown;
            }
        }
    }
}
