using System;

namespace QuickConnectPlugin {

    public enum ConnectionMethodType {

        Unknown = 0,
        RemoteDesktop = 1,
        RemoteDesktopConsole = 2,
        vSphereClient = 3,
        PuttySSH = 4,
        PuttyTelnet = 5
    }
}
