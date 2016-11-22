using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class LinuxPasswordChangerTests {

        [TestCase("RHEL6.6", "root", "12345678", Description = "RHEL 6.6 / OpenSSH_5.3p1")]
        [TestCase("openSUSE13.1", "root", "12345678", Description = "openSUSE 13.1 / OpenSSH_6.2p2")]
        [TestCase("openSUSE13.2-KDE", "root", "12345678", Description = "openSUSE 13.2 / OpenSSH_6.6.1p1")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var linuxPasswordChanger = new LinuxPasswordChanger();
            Assert.DoesNotThrow(() => linuxPasswordChanger.ChangePassword(ipAddress, username, password, password));
        }
    }
}
