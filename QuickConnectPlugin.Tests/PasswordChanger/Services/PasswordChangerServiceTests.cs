using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;

namespace QuickConnectPlugin.Tests.PasswordChanger.Services {

    [TestFixture]
    public class PasswordChangerServiceTests {

        [Test]
        public void ChangePassword() {
            var passwordDatabaseMock = new Mock<IPasswordDatabase>();
            var passwordChangerExFactoryMock = new Mock<IPasswordChangerExFactory>();
            var passwordChangerExMock = new Mock<IPasswordChangerEx>();
            passwordChangerExFactoryMock.Setup(x => x.Create(It.IsAny<HostType>())).Returns(passwordChangerExMock.Object);
            var hostTypeMapperMock = new Mock<IHostTypeMapper>();
            hostTypeMapperMock.Setup(x => x.Get(It.IsAny<IHostPwEntry>())).Returns(HostType.Unknown);

            var passwordChangerService = new PasswordChangerService(
                passwordDatabaseMock.Object,
                passwordChangerExFactoryMock.Object,
                hostTypeMapperMock.Object
            );

            var hostPwEntry = new InMemoryHostPwEntry() {
                IPAddress = "localhost",
                Username = "username",
                Password = "password"
            };

            passwordChangerService.ChangePassword(hostPwEntry, "newPassword");

            Assert.AreEqual("newPassword", hostPwEntry.Password);
            passwordChangerExFactoryMock.Verify(v => v.Create(HostType.Unknown), Times.Once);
            hostTypeMapperMock.Verify(v => v.Get(hostPwEntry), Times.Once);
            passwordChangerExMock.Verify(v => v.ChangePassword(hostPwEntry, "newPassword"), Times.Once);
            passwordDatabaseMock.Verify(v => v.Save(), Times.Never);
        }

        [Test]
        public void Save() {
            var passwordDatabaseMock = new Mock<IPasswordDatabase>();
            var passwordChangerExFactoryMock = new Mock<IPasswordChangerExFactory>();
            var passwordChangerExMock = new Mock<IPasswordChangerEx>();
            passwordChangerExFactoryMock.Setup(x => x.Create(It.IsAny<HostType>())).Returns(passwordChangerExMock.Object);
            var hostTypeMapperMock = new Mock<IHostTypeMapper>();
            hostTypeMapperMock.Setup(x => x.Get(It.IsAny<IHostPwEntry>())).Returns(HostType.Unknown);

            var passwordChangerService = new PasswordChangerService(
                 passwordDatabaseMock.Object,
                 passwordChangerExFactoryMock.Object,
                 hostTypeMapperMock.Object
             );

            passwordChangerService.SaveDatabase();

            passwordChangerExFactoryMock.Verify(v => v.Create(It.IsAny<HostType>()), Times.Never);
            hostTypeMapperMock.Verify(v => v.Get(It.IsAny<IHostPwEntry>()), Times.Never);
            passwordChangerExFactoryMock.Verify(v => v.Create(It.IsAny<HostType>()), Times.Never);
            passwordDatabaseMock.Verify(v => v.Save(), Times.Once);
        }
    }
}
