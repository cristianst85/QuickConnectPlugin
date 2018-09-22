using System;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Tests.PasswordChanger.Services;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class BatchPasswordChangerWorkerTests {

        [Test]
        public void ChangePasswordOnMultipleHosts() {
            var passwordChangerService = new MockPasswordChangerService();
            var pwHostEntries = new Collection<IHostPwEntry>() {
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost1",
                    Username = "username1",
                    Password = "password1"
                },
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost2",
                    Username = "username2",
                    Password = "password2"
                },
            };
            var batchPasswordChangerWorker = new BatchPasswordChangerWorker(passwordChangerService, pwHostEntries, "newPassword");

            int changedEventCount = 0;
            int errorEventCount = 0;
            int completedEventCount = 0;

            batchPasswordChangerWorker.Changed += (o, e) => { changedEventCount++; };
            batchPasswordChangerWorker.Error += (o, e) => { errorEventCount++; };
            batchPasswordChangerWorker.Completed += (o, e) => { completedEventCount++; };
            batchPasswordChangerWorker.Run();

            Assert.AreEqual(pwHostEntries.Count, changedEventCount);
            Assert.AreEqual(0, errorEventCount);
            Assert.AreEqual(1, completedEventCount);

            Assert.AreEqual(pwHostEntries.Count, passwordChangerService.ChangePasswordCount);
            Assert.AreEqual(1, passwordChangerService.SaveDatabaseCount);
        }

        [Test]
        public void ChangePasswordOnMultipleHostsAndSaveDatabaseAfterEachUpdate() {
            var passwordChangerService = new MockPasswordChangerService();
            var pwHostEntries = new Collection<IHostPwEntry>() {
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost1",
                    Username = "username1",
                    Password = "password1"
                },
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost2",
                    Username = "username2",
                    Password = "password2"
                },
            };
            var batchPasswordChangerWorker = new BatchPasswordChangerWorker(passwordChangerService, pwHostEntries, "newPassword");
            batchPasswordChangerWorker.SaveDatabaseAfterEachUpdate = true;

            int changedEventCount = 0;
            int errorEventCount = 0;
            int completedEventCount = 0;

            batchPasswordChangerWorker.Changed += (o, e) => { changedEventCount++; };
            batchPasswordChangerWorker.Error += (o, e) => { errorEventCount++; };
            batchPasswordChangerWorker.Completed += (o, e) => { completedEventCount++; };
            batchPasswordChangerWorker.Run();

            Assert.AreEqual(pwHostEntries.Count, changedEventCount);
            Assert.AreEqual(0, errorEventCount);
            Assert.AreEqual(1, completedEventCount);

            Assert.AreEqual(pwHostEntries.Count, passwordChangerService.ChangePasswordCount);
            Assert.AreEqual(pwHostEntries.Count, passwordChangerService.SaveDatabaseCount);
        }

        [Test]
        public void ChangePasswordOnMultipleHostsWithError() {
            var pwHostEntries = new Collection<IHostPwEntry>() {
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost1",
                    Username = "username1",
                    Password = "password1"
                },
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost2",
                    Username = "username2",
                    Password = "password2"
                },
                new InMemoryHostPwEntry() { 
                    IPAddress = "localhost3",
                    Username = "username3",
                    Password = "password3"
                },
            };

            var mock = new Mock<IPasswordChangerService>();
            mock.CallBase = true;
            mock.Setup(
                m => m.ChangePassword(
                    It.Is<IHostPwEntry>(x => x.IPAddress == pwHostEntries[1].IPAddress),
                    It.IsAny<String>()
                )
            ).Throws<Exception>();

            var batchPasswordChangerWorker = new BatchPasswordChangerWorker(mock.Object, pwHostEntries, "newPassword");
            batchPasswordChangerWorker.SaveDatabaseAfterEachUpdate = true;

            int changedEventCount = 0;
            int errorEventCount = 0;
            int completedEventCount = 0;

            batchPasswordChangerWorker.Changed += (o, e) => { changedEventCount++; };
            batchPasswordChangerWorker.Error += (o, e) => { errorEventCount++; };
            batchPasswordChangerWorker.Completed += (o, e) => { completedEventCount++; };
            batchPasswordChangerWorker.Run();

            Assert.AreEqual(2, changedEventCount);
            Assert.AreEqual(1, errorEventCount);
            Assert.AreEqual(1, completedEventCount);

            mock.Verify(x => x.ChangePassword(pwHostEntries[0], "newPassword"), Times.Once);
            mock.Verify(x => x.ChangePassword(pwHostEntries[2], "newPassword"), Times.Once);

            mock.Verify(x => x.SaveDatabase(), Times.Exactly(2));
        }
    }
}
