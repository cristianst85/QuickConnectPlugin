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

        private readonly string databasePath = Path.GetFullPath(@"..\..\..\QuickConnectPlugin.Tests.Resources\sample.kdbx");
        private readonly string databasePassword = "12345678";

        private PwDatabase pwDatabase;

        [SetUp]
        public void Setup() {
            Assert.IsTrue(File.Exists(databasePath));
            var ioConnectionInfo = new IOConnectionInfo() {
                Path = databasePath
            };

            var key = new CompositeKey();
            key.AddUserKey(new KcpPassword(databasePassword));

            pwDatabase = new PwDatabase();
            pwDatabase.Open(ioConnectionInfo, key, null);
        }

        [TearDown]
        public void Cleanup() {
            if (pwDatabase != null) {
                pwDatabase.Close();
            }
        }

        [Test]
        public void HostPwEntry() {
            var expectedConnectionMethods = new Collection<ConnectionMethodType>() {
                ConnectionMethodType.RemoteDesktop,
                ConnectionMethodType.RemoteDesktopConsole,
            };

            var entry = new HostPwEntry(
                this.findEntryByTitle("Windows host sample", true), this.pwDatabase, "OS", "IP Address"
            );

            Assert.AreEqual("Administrator", entry.GetUsername());
            Assert.AreEqual("12345678", entry.GetPassword());
            Assert.AreEqual("192.168.0.100", entry.IPAddress);
            CollectionAssert.AreEquivalent(expectedConnectionMethods, entry.ConnectionMethods);
            Assert.IsTrue(entry.HasIPAddress);
            Assert.IsTrue(entry.HasConnectionMethods);
        }

        [TestCase("Linux host sample")]
        [TestCase("Linux host sample (with referenced fields)")]
        public void HostPwEntryWithAndWithoutReferencedFields(String title) {
            var expectedConnectionMethods = new Collection<ConnectionMethodType>() {
                ConnectionMethodType.PuttySSH
            };

            var entry = new HostPwEntry(
               this.findEntryByTitle(title, true), this.pwDatabase, "OS", "IP Address"
            );

            Assert.AreEqual("root", entry.GetUsername());
            Assert.AreEqual("123456789", entry.GetPassword());
            Assert.AreEqual("192.168.0.110", entry.IPAddress);
            CollectionAssert.AreEquivalent(expectedConnectionMethods, entry.ConnectionMethods);
            Assert.IsTrue(entry.HasIPAddress);
            Assert.IsTrue(entry.HasConnectionMethods);
        }

        private PwEntry findEntryByTitle(String title, bool recursive) {
            foreach (PwEntry entry in this.pwDatabase.RootGroup.GetEntries(recursive).CloneShallowToList()) {
                if (entry.Strings.Get("Title").ReadString().Equals(title)) {
                    return entry;
                }
            }
            return null;
        }
    }
}
