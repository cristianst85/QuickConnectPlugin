using System;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [Ignore("IntegrationTest")]
    [TestFixture]
    public class LinuxPasswordChangerTests {

        [TestCase("RHEL6.6", "root", "12345678", Description = "RHEL 6.6 / OpenSSH_5.3p1")]
        [TestCase("openSUSE13.1", "root", "12345678", Description = "openSUSE 13.1 / OpenSSH_6.2p2")]
        [TestCase("openSUSE13.1:2222", "root", "12345678", Description = "openSUSE 13.1 / OpenSSH_6.2p2")]
        [TestCase("openSUSE13.2-KDE", "root", "12345678", Description = "openSUSE 13.2 / OpenSSH_6.6.1p1")]
        public void ChangePassword(String ipAddress, String username, String password) {
            var linuxPasswordChanger = new LinuxPasswordChanger();
            Assert.DoesNotThrow(() => linuxPasswordChanger.ChangePassword(ipAddress, username, password, password));
        }
        
        [TestCase("RHEL6.6", "testkeepass", "aaabbbccc123!", "xxxyyyzzz456!", Description = "RHEL 6.6 / OpenSSH_5.3p1 / Non-root user")]
        [TestCase("openSUSE13.2-KDE", "testkeepass", "aaabbbccc123!", "xxxyyyzzz456!", Description = "openSUSE 13.2 / OpenSSH_6.6.1p1 / Non-root user")]
        public void ChangePasswordForNonRootUser(String ipAddress, String username, String password, String newPassword) {
            var linuxPasswordChanger = new LinuxPasswordChanger();
            Assert.DoesNotThrow(() => linuxPasswordChanger.ChangePassword(ipAddress, username, password, newPassword));
            Assert.DoesNotThrow(() => linuxPasswordChanger.ChangePassword(ipAddress, username, newPassword, password));
        }

        [TestCase("RHEL6.6", "testkeepass", "aaabbbccc123!", "aaabbbccc123!", "Error changing password. Got 'Password unchanged / New password' from shell which didn't match the expected 'Re.*new password' regex pattern.", Description = "RHEL 6.6 / OpenSSH_5.3p1 / Non-root user")]
        [TestCase("RHEL6.6", "testkeepass", "aaabbbccc123!", "aaabbbccc456!", "Error changing password. Got 'BAD PASSWORD: is too similar to the old one / New password' from shell which didn't match the expected 'Re.*new password' regex pattern.", Description = "RHEL 6.6 / OpenSSH_5.3p1 / Non-root user")]
        [TestCase("openSUSE13.2-KDE", "testkeepass", "aaabbbccc123!", "aaabbbccc123!", "Error changing password. Got 'Password unchanged / passwd: password unchanged' from shell which didn't match the expected 'Re.*new password' regex pattern.", Description = "openSUSE 13.2 / OpenSSH_6.6.1p1 / Non-root user")]
        [TestCase("openSUSE13.2-KDE", "testkeepass", "aaabbbccc123!", "aaabbbccc456!", "Error changing password. Got 'BAD PASSWORD: is too similar to the old one / passwd: password unchanged' from shell which didn't match the expected 'Re.*new password' regex pattern.", Description = "openSUSE 13.2 / OpenSSH_6.6.1p1 / Non-root user")]
        public void ChangePasswordForNonRootUserThrowsException(String ipAddress, String username, String password, String newPassword, String expectedExceptionMessage) {
            var linuxPasswordChanger = new LinuxPasswordChanger();
            var exception = Assert.Throws<Exception>(() => linuxPasswordChanger.ChangePassword(ipAddress, username, password, newPassword));
            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
