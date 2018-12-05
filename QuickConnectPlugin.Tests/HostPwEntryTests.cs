using System;
using System.Collections.ObjectModel;
using System.IO;
using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class HostPwEntryTests {

        private readonly string databasePath = @"..\..\..\QuickConnectPlugin.Tests.Resources\sample.kdbx";
        private readonly string databasePassword = "12345678";

        private PwDatabase pwDatabase;
        private IFieldMapper fieldMapper;

        [SetUp]
        public void Setup() {
            var fullDatabasePath = Path.Combine(TestContext.CurrentContext.TestDirectory, databasePath);

            Assert.IsTrue(File.Exists(fullDatabasePath));
            var ioConnectionInfo = new IOConnectionInfo() {
                Path = fullDatabasePath
            };

            var key = new CompositeKey();
            key.AddUserKey(new KcpPassword(databasePassword));

            this.pwDatabase = new PwDatabase();
            this.pwDatabase.Open(ioConnectionInfo, key, null);

            this.fieldMapper = new InMemoryFieldMapper() {
                HostAddress = "IP Address",
                ConnectionMethod = "OS"
            };
        }

        [TearDown]
        public void Cleanup() {
            if (this.pwDatabase != null) {
                this.pwDatabase.Close();
            }
        }

        [Test]
        public void HostPwEntry() {
            var expectedConnectionMethods = new Collection<ConnectionMethodType>() {
                ConnectionMethodType.RemoteDesktop,
                ConnectionMethodType.RemoteDesktopConsole,
            };

            var entry = new HostPwEntry(
                PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, "Windows host sample", true),
                this.pwDatabase,
                this.fieldMapper
            );

            Assert.AreEqual("Administrator", entry.GetUsername());
            Assert.AreEqual("12345678", entry.GetPassword());
            Assert.AreEqual("192.168.0.100", entry.IPAddress);
            CollectionAssert.AreEquivalent(expectedConnectionMethods, entry.ConnectionMethods);
            Assert.IsTrue(entry.HasIPAddress);
            Assert.IsTrue(entry.HasConnectionMethods);
            Assert.AreEqual(DateTime.Parse("2016-03-16 23:19:53"), entry.LastModificationTime);
        }

        [TestCase("Linux host sample", "2016-03-18 21:05:15")]
        [TestCase("Linux host sample (with referenced fields)", "2016-03-16 23:19:24")]
        public void HostPwEntryWithAndWithoutReferencedFields(String title, String lastModificationTime) {
            var expectedConnectionMethods = new Collection<ConnectionMethodType>() {
                ConnectionMethodType.PuttySSH,
                ConnectionMethodType.WinSCP
            };

            var entry = new HostPwEntry(
                    PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, title, true),
                    this.pwDatabase,
                    this.fieldMapper
            );

            Assert.AreEqual("root", entry.GetUsername());
            Assert.AreEqual("123456789", entry.GetPassword());
            Assert.AreEqual("192.168.0.110", entry.IPAddress);
            CollectionAssert.AreEquivalent(expectedConnectionMethods, entry.ConnectionMethods);
            Assert.IsTrue(entry.HasIPAddress);
            Assert.IsTrue(entry.HasConnectionMethods);
            Assert.AreEqual(DateTime.Parse(lastModificationTime), entry.LastModificationTime);
        }

        [TestCase("Linux host sample", null)]
        [TestCase("Linux host sample", "")]
        [TestCase("Linux host sample", "FieldNameThatDoesNotExist")]
        public void HostPwEntryGetAdditionalOptionsAssertDoesNotThrow(String title, String additionalOptionsFieldName) {
            var fieldMapper = new InMemoryFieldMapper() {
                HostAddress = "IP Address",
                ConnectionMethod = "OS",
                AdditionalOptions = additionalOptionsFieldName
            };

            var entry = new HostPwEntry(
                    PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, title, true),
                    this.pwDatabase,
                    fieldMapper
            );

            String additionalOptions = null;
            Assert.DoesNotThrow(() => additionalOptions = entry.AdditionalOptions);
            Assert.That(additionalOptions, Is.Null.Or.Empty);
        }

        [TestCase("Generic sample", "2018-10-10T00:35:45+03:00")]
        public void UpdateLastModificationTime(String title, string lastModificationTime) {
            // Arrange
            var pwEntry = PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, title, true);
            Assert.IsNotNull(pwEntry);

            var hostPwEntry = new HostPwEntry(pwEntry,  this.pwDatabase,  fieldMapper);
            Assert.That(hostPwEntry.LastModificationTime.ToUniversalTime(), Is.EqualTo(DateTime.Parse(lastModificationTime).ToUniversalTime()));

            // Act
            var utcNow = DateTime.UtcNow;
            hostPwEntry.LastModificationTime = utcNow;

            // Assert
            Assert.AreEqual(utcNow, hostPwEntry.LastModificationTime.ToUniversalTime());
        }

        [TestCase("Linux host sample (with placeholders)", "command:-pw 12345678")]
        public void HostPwEntryGetAdditionalOptionsWithPlaceholders(String title, string expectedAdditionalOptions) {
            // Arrange
            var fieldMapper = new InMemoryFieldMapper() {
                AdditionalOptions = "Notes"
            };

            // Act
            var entry = new HostPwEntry(
                  PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, title, true),
                  this.pwDatabase,
                  fieldMapper
            );

            // Assert
            String additionalOptions = null;
            Assert.DoesNotThrow(() => additionalOptions = entry.AdditionalOptions);
            Assert.That(additionalOptions, Is.EqualTo(expectedAdditionalOptions));
        }
    }
}
