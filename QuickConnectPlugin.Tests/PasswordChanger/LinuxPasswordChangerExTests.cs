using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class LinuxPasswordChangerExTests {

        [TestCase]
        public void ChangePassword() {
            var hostPwEntryMock = new Mock<IHostPwEntry>();
            hostPwEntryMock.Setup(x => x.IPAddress).Returns("ipAddress");
            hostPwEntryMock.Setup(x => x.GetUsername()).Returns("username");
            hostPwEntryMock.Setup(x => x.GetPassword()).Returns("password");

            var linuxPasswordChangerMock = new Mock<ILinuxPasswordChanger>();

            var passwordChangerFactoryMock = new Mock<ILinuxPasswordChangerFactory>();
            passwordChangerFactoryMock.Setup(x => x.Create()).Returns(linuxPasswordChangerMock.Object);

            var linuxPasswordChangerEx = new LinuxPasswordChangerEx(passwordChangerFactoryMock.Object);
            linuxPasswordChangerEx.ChangePassword(hostPwEntryMock.Object, "newPassword");

            hostPwEntryMock.VerifyGet(v => v.AdditionalOptions, Times.Once);
            hostPwEntryMock.VerifyGet(v => v.IPAddress, Times.Once);
            hostPwEntryMock.Verify(v => v.GetUsername(), Times.Once);
            hostPwEntryMock.Verify(v => v.GetPassword(), Times.Once);

            linuxPasswordChangerMock.VerifySet(v => v.SshPort = null, Times.Never);
            linuxPasswordChangerMock.Verify(v => v.ChangePassword("ipAddress", "username", "password", "newPassword"), Times.Once);
            passwordChangerFactoryMock.Verify(v => v.Create(It.IsAny<int>()), Times.Never);
            passwordChangerFactoryMock.Verify(v => v.Create(), Times.Once);
        }

        [TestCase]
        public void ChangePasswordOnCustomPort() {
            var hostPwEntryMock = new Mock<IHostPwEntry>();
            hostPwEntryMock.Setup(x => x.IPAddress).Returns("ipAddress");
            hostPwEntryMock.Setup(x => x.GetUsername()).Returns("username");
            hostPwEntryMock.Setup(x => x.GetPassword()).Returns("password");
            hostPwEntryMock.Setup(x => x.AdditionalOptions).Returns("port:2672");

            var linuxPasswordChangerMock = new Mock<ILinuxPasswordChanger>();

            var passwordChangerFactoryMock = new Mock<ILinuxPasswordChangerFactory>();
            passwordChangerFactoryMock.Setup(x => x.Create(It.IsAny<int>())).Returns(linuxPasswordChangerMock.Object)
                    .Callback<int>(value => linuxPasswordChangerMock.Object.SshPort = value);

            var linuxPasswordChangerEx = new LinuxPasswordChangerEx(passwordChangerFactoryMock.Object);
            linuxPasswordChangerEx.ChangePassword(hostPwEntryMock.Object, "newPassword");

            hostPwEntryMock.VerifyGet(v => v.AdditionalOptions, Times.Once);
            hostPwEntryMock.VerifyGet(v => v.IPAddress, Times.Once);
            hostPwEntryMock.Verify(v => v.GetUsername(), Times.Once);
            hostPwEntryMock.Verify(v => v.GetPassword(), Times.Once);

            linuxPasswordChangerMock.VerifySet(x => x.SshPort = It.Is<int>(y => y == 2672), Times.Once);
            linuxPasswordChangerMock.Verify(v => v.ChangePassword("ipAddress", "username", "password", "newPassword"), Times.Once);
            passwordChangerFactoryMock.Verify(v => v.Create(2672), Times.Once);
            passwordChangerFactoryMock.Verify(v => v.Create(), Times.Never);
        }
    }
}
