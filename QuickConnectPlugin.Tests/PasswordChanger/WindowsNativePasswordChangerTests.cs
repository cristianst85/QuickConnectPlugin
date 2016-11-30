using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class WindowsNativePasswordChangerTests {

        [TestCase("W7SP1X64-1", "test", "12345678", Description = "Local account on local host / Windows 7 SP1 x64")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var windowsNativePasswordChanger = new WindowsNativePasswordChanger(WindowsADSIProvider.None);
            Assert.DoesNotThrow(() => windowsNativePasswordChanger.ChangePassword(ipAddress, username, password, password));
        }

        [TestCase("W2K3R2EE", "Administrator", "12345678", Description = "Local account on remote host / Windows Server 2003 R2 Enterprise Edition")]
        [TestCase("W2K8R2EE", "Administrator", "123456789abc!", Description = "Local account on remote host / Windows Server 2008 R2 Enterprise Edition")]
        [TestCase("W7SP1X64-2", "Administrator", "12345678", Description = "Local account on remote host/ Windows 7 SP1 x64")]
        public void ChangePasswordOnRemoteServers(String ipAddress, String username, String password) {
            var windowsNativePasswordChanger = new WindowsNativePasswordChanger(WindowsADSIProvider.None);
            Assert.DoesNotThrow(() => windowsNativePasswordChanger.ChangePassword(ipAddress, username, password, password));
        }

        [TestCase("W7SP1X64-1", "inexistentUser", "12345678", Description = "Inexistent local account on local host / Windows 7 SP1 x64")]
        public void ChangePasswordThrowsException(String ipAddress, String username, String password) {
            var windowsNativePasswordChanger = new WindowsNativePasswordChanger(WindowsADSIProvider.WinNT);
            Assert.Throws<COMException>(() => windowsNativePasswordChanger.ChangePassword(ipAddress, username, password, password));
        }
    }
}
