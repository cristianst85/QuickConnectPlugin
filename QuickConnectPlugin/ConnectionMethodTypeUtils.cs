using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickConnectPlugin {

    public static class ConnectionMethodTypeUtils {

        public static ICollection<ConnectionMethodType> GetConnectionMethodsFromString(String description) {
            if (String.IsNullOrEmpty(description)) {
                return new Collection<ConnectionMethodType>();
            }
            var connectionMethods = new Collection<ConnectionMethodType>();
            if (useRDP(description)) {
                connectionMethods.Add(ConnectionMethodType.RemoteDesktop);
                connectionMethods.Add(ConnectionMethodType.RemoteDesktopConsole);
            };
            if (useSSH(description)) {
                connectionMethods.Add(ConnectionMethodType.PuttySSH);
            };
            if (useTelnet(description)) {
                connectionMethods.Add(ConnectionMethodType.PuttyTelnet);
            };
            if (description.ToLower().Contains("esxi") || description.ToLower().Contains("vcenter")) {
                connectionMethods.Add(ConnectionMethodType.vSphereClient);
            };
            return connectionMethods;
        }

        private static bool useRDP(String description) {
            if (description.ToLower().Contains("windows") || description.ToLower().Contains("rdp")) {
                return true;
            }
            return false;
        }

        private static bool useSSH(String description) {
            if (description.ToLower().Contains("linux") || description.ToLower().Contains("ssh")) {
                return true;
            }
            foreach (var name in LinuxDistributionsNames) {
                if (description.ToLower().Contains(name.ToLower())) {
                    return true;
                }
            }
            foreach (var name in OSesWithSSH) {
                if (description.ToLower().Contains(name.ToLower())) {
                    return true;
                }
            }
            return false;
        }

        private static bool useTelnet(String description) {
            if (description.ToLower().Contains("telnet")) {
                return true;
            }
            foreach (var name in OSesWithTelnet) {
                if (description.ToLower().Contains(name.ToLower())) {
                    return true;
                }
            }
            return false;
        }

        private static readonly ICollection<String> LinuxDistributionsNames = new Collection<String>() {
            "openSUSE",
            "SUSE",
            "SLES",
            "Red Hat",
            "RHEL",
            "CentOS",
            "Debian",
            "Gentoo",
            "Ubuntu",
            "Fedora",
            "Mandriva",
            "Mageia",
            "Arch",
            "Slackware",
            "Mint"
         };

        private static readonly ICollection<String> OSesWithSSH = new Collection<String>() {
           "Fabric OS",
           "Network OS",
           "Network Operating System"
        };

        private static readonly ICollection<String> OSesWithTelnet = new Collection<String>() {
           "OpenWrt"
        };
    }
}
