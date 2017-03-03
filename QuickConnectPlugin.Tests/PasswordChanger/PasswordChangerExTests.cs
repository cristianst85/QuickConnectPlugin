using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class PasswordChangerExTests {

        [TestCase]
        public void ChangePassword() {
            var hostPwEntryMock = new Mock<IHostPwEntry>();
            hostPwEntryMock.Setup(x => x.IPAddress).Returns("ipAddress");
            hostPwEntryMock.Setup(x => x.GetUsername()).Returns("username");
            hostPwEntryMock.Setup(x => x.GetPassword()).Returns("password");

            var passwordChangerMock = new Mock<IPasswordChanger>();

            var passwordChangerEx = new PasswordChangerEx(passwordChangerMock.Object);
            passwordChangerEx.ChangePassword(hostPwEntryMock.Object, "newPassword");

            passwordChangerMock.Verify(v => v.ChangePassword("ipAddress", "username", "password", "newPassword"), Times.Once);
            hostPwEntryMock.VerifyGet(v => v.IPAddress, Times.Once);
            hostPwEntryMock.Verify(v => v.GetUsername(), Times.Once);
            hostPwEntryMock.Verify(v => v.GetPassword(), Times.Once);
        }
    }
}
