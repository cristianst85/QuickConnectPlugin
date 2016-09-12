using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class LinuxPasswordChangerTests {

        [TestCase("opensuse13.1", "root", "12345678", Description = "openSUSE 13.1")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var linuxPasswordChanger = new LinuxPasswordChanger();
            Assert.DoesNotThrow(() => linuxPasswordChanger.ChangePassword(ipAddress, username, password, password));
        }
    }
}
