using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class HostTypeSafeConverterTests {

        [TestCase(ConnectionMethodType.RemoteDesktop, HostType.Windows)]
        [TestCase(ConnectionMethodType.RemoteDesktopConsole, HostType.Windows)]
        [TestCase(ConnectionMethodType.vSphereClient, HostType.ESXi)]
        [TestCase(ConnectionMethodType.PuttySSH, HostType.Linux)]
        [TestCase(ConnectionMethodType.PuttyTelnet, HostType.Unknown)]
        [TestCase(ConnectionMethodType.Unknown, HostType.Unknown)]
        public void Convert(ConnectionMethodType connectionMethod, HostType expectedHostType) {
            Assert.AreEqual(expectedHostType, new HostTypeSafeConverter().Convert(connectionMethod));
        }
    }
}
