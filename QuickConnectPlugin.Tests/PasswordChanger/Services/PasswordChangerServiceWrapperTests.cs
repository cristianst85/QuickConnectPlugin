using DisruptiveSoftware.Time.Clocks;
using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;
using System;

namespace QuickConnectPlugin.Tests.PasswordChanger.Services {

    [TestFixture]
    public class PasswordChangerServiceWrapperTests {

        [Test]
        public void ChangePassword() {
            // Arrange
            var passwordDatabaseMock = new Mock<IPasswordDatabase>();
            var passwordChangerMock = new Mock<IPasswordChanger>();

            var now = DateTime.Now;

            var clockMock = new Mock<IClock>();
            clockMock.Setup(x => x.Now).Returns(now);

            var passwordChangerService = new PasswordChangerServiceWrapper(
                passwordDatabaseMock.Object,
                passwordChangerMock.Object,
                clockMock.Object
            );

            var hostPwEntryMock = new Mock<IHostPwEntry>();
            hostPwEntryMock.SetupGet(x => x.IPAddress).Returns("localhost");
            hostPwEntryMock.Setup(x => x.GetUsername()).Returns("username");
            hostPwEntryMock.Setup(x => x.GetPassword()).Returns("password");

            // Act
            passwordChangerService.ChangePassword(hostPwEntryMock.Object, "newPassword");

            // Assert
            hostPwEntryMock.Verify(x => x.UpdatePassword("newPassword"), Times.Once);
            hostPwEntryMock.VerifySet(v => v.LastModificationTime = now, Times.Once);

            passwordDatabaseMock.Verify(v => v.Save(), Times.Never);
            passwordChangerMock.Verify(v => v.ChangePassword("localhost", "username", "password", "newPassword"), Times.Once);
            clockMock.Verify(v => v.Now, Times.Once);
        }

        [Test]
        public void SaveDatabase() {
            // Arrange
            var passwordDatabaseMock = new Mock<IPasswordDatabase>();
            var passwordChangerMock = new Mock<IPasswordChanger>();

            var now = DateTime.Now;

            var clockMock = new Mock<IClock>();
            clockMock.Setup(x => x.Now).Returns(now);

            var passwordChangerService = new PasswordChangerServiceWrapper(
                passwordDatabaseMock.Object,
                passwordChangerMock.Object,
                clockMock.Object
            );

            // Act
            passwordChangerService.SaveDatabase();

            // Assert
            passwordDatabaseMock.Verify(v => v.Save(), Times.Once);
            passwordChangerMock.Verify(v => v.ChangePassword(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>()), Times.Never);
            clockMock.Verify(v => v.Now, Times.Never);
        }
    }
}
