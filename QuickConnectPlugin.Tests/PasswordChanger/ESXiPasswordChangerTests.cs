using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class ESXiPasswordChangerTests {

        [TestCase("10.10.0.31", "root", "123456789", Description = "ESXi 5.1u1")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var esxiPasswordChanger = new ESXiPasswordChanger();
            Assert.DoesNotThrow(() => esxiPasswordChanger.ChangePassword(ipAddress, username, password, password));
        }
    }
}
