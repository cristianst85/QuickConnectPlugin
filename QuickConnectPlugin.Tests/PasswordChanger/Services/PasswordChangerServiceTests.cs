using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;

namespace QuickConnectPlugin.Tests.PasswordChanger.Services {
    
    [TestFixture]
    public class PasswordChangerServiceTests {

        [Test]
        public void ChangePassword() {
            var passwordDatabase = new MockPasswordDatabase();
            var passwordChangerFactory = new MockPasswordChangerFactory();
            var hostTypeMapper = new FixedHostTypeMapper(HostType.Unknown);
            var passwordChangerService = new PasswordChangerService(passwordDatabase, passwordChangerFactory, hostTypeMapper);
            var hostPwEntry = new InMemoryHostPwEntry() { 
                IPAddress = "localhost",
                Username = "username",
                Password = "password"
            };
            passwordChangerService.ChangePassword(hostPwEntry, "newPassword");
            Assert.AreEqual("newPassword", hostPwEntry.Password);
            Assert.AreEqual(1, passwordChangerFactory.PasswordChanger.ChangePasswordCount);
            Assert.AreEqual(hostPwEntry.IPAddress, passwordChangerFactory.PasswordChanger.Host);
            Assert.AreEqual(hostPwEntry.Username, passwordChangerFactory.PasswordChanger.Username);
            Assert.AreEqual("password", passwordChangerFactory.PasswordChanger.Password);
            Assert.AreEqual(hostPwEntry.Password, passwordChangerFactory.PasswordChanger.NewPassword);
            Assert.AreEqual(0, passwordDatabase.SaveCount);
        }

        [Test]
        public void Save() {
            var passwordDatabase = new MockPasswordDatabase();
            var passwordChangerFactory = new MockPasswordChangerFactory();
            var hostTypeMapper = new FixedHostTypeMapper(HostType.Unknown);
            var passwordChangerService = new PasswordChangerService(passwordDatabase, passwordChangerFactory, hostTypeMapper);
            passwordChangerService.SaveDatabase();
            Assert.AreEqual(1, passwordDatabase.SaveCount);
        }
    }
}
