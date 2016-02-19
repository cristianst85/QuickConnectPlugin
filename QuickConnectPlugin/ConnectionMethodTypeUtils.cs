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
            if (description.ToLower().Contains("windows")) {
                connectionMethods.Add(ConnectionMethodType.RemoteDesktop);
                connectionMethods.Add(ConnectionMethodType.RemoteDesktopConsole);
            };
            if (description.ToLower().Contains("esxi") || description.ToLower().Contains("vcenter")) {
                connectionMethods.Add(ConnectionMethodType.vSphereClient);
            };
            if (description.ToLower().Contains("linux")) {
                connectionMethods.Add(ConnectionMethodType.PuttySSH);
            };
            return connectionMethods;
        }
    }
}
