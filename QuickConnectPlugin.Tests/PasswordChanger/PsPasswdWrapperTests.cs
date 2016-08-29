using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class PsPasswdWrapperTests {

        [TestCase(@"C:\Program Files (x86)\SysinternalsSuite\pspasswd.exe", false, Description = "Sysinternals PsPasswd v1.23")]
        [TestCase(@"C:\Program Files (x86)\SysinternalsSuite\pspasswd_122.exe", true, Description = "Sysinternals PsPasswd v1.22")]
        public void IsSupportedVersion(String psPasswdPath, bool expectedResult) {
            Assert.AreEqual(expectedResult, PsPasswdWrapper.IsSupportedVersion(psPasswdPath));
        }

        [TestCase(@"C:\Program Files (x86)\SysinternalsSuite\pspasswd.exe", true, Description = "Sysinternals PsPasswd v1.23")]
        [TestCase(@"C:\Program Files (x86)\SysinternalsSuite\pspasswd_122.exe", true, Description = "Sysinternals PsPasswd v1.22")]
        [TestCase(@"C:\Program Files (x86)\SysinternalsSuite\procexp.exe", false)]
        public void IsPsPasswdUtility(String psPasswdPath, bool expectedResult) {
            Assert.AreEqual(expectedResult, PsPasswdWrapper.IsPsPasswdUtility(psPasswdPath));
        }

        [TestCase("10.10.0.30", "Administrator", "12345678", Description = "Windows Server 2003 R2 Enterprise Edition")]
        [TestCase("10.10.0.23", "Administrator", "123456789abc!", Description = "Windows Server 2008 R2 Enterprise Edition")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var psPasswdWrapper = new PsPasswdWrapper(@"C:\Program Files (x86)\SysinternalsSuite\pspasswd_122.exe");
            Assert.DoesNotThrow(() => psPasswdWrapper.ChangePassword(ipAddress, username, password, username, password));
        }
    }
}
