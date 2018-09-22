using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class HostTypeConverterTests {

        [TestCase(ConnectionMethodType.RemoteDesktop, HostType.Windows)]
        [TestCase(ConnectionMethodType.RemoteDesktopConsole, HostType.Windows)]
        [TestCase(ConnectionMethodType.vSphereClient, HostType.ESXi)]
        [TestCase(ConnectionMethodType.PuttySSH, HostType.Linux)]
        public void Convert(ConnectionMethodType connectionMethod, HostType expectedHostType) {
            Assert.AreEqual(expectedHostType, new HostTypeConverter().Convert(connectionMethod));
        }

        [TestCase(ConnectionMethodType.Unknown)]
        public void ConvertThrowsException(ConnectionMethodType connectionMethod) {
            Assert.Throws<NotSupportedException>(() => new HostTypeConverter().Convert(connectionMethod));
        }
    }
}
