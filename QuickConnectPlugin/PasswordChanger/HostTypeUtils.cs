using System;

namespace QuickConnectPlugin.PasswordChanger {

    public static class HostTypeUtils {

        public static HostType Convert(ConnectionMethodType connectionMethod) {
            if (connectionMethod == ConnectionMethodType.RemoteDesktop || connectionMethod == ConnectionMethodType.RemoteDesktopConsole) {
                return HostType.Windows;
            }
            else if (connectionMethod == ConnectionMethodType.vSphereClient) {
                return HostType.ESXi;
            }
            else if (connectionMethod == ConnectionMethodType.PuttySSH) {
                return HostType.Linux;
            }
            else {
                throw new NotSupportedException(String.Format("{0} '{1}' is not supported.", typeof(ConnectionMethodType), connectionMethod));
            }
        }
    }
}
