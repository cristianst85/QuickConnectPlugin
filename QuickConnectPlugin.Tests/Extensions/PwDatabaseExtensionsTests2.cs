using System;
using System.Collections.ObjectModel;
using System.IO;
using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using NUnit.Framework;
using QuickConnectPlugin.Extensions;

namespace QuickConnectPlugin.Tests.Extensions {

    [TestFixture("sample-templates-classic.kdbx")]
    public class PwDatabaseExtensionsTests2 {

        private readonly string databaseFilePath = Path.GetFullPath(@"..\..\..\QuickConnectPlugin.Tests.Resources\");
        private readonly string databasePassword = "12345678";

        private String databaseFileName;
        private PwDatabase pwDatabase;

        public PwDatabaseExtensionsTests2(String dbName) {
            this.databaseFileName = dbName;
        }

        [SetUp]
        public void Setup() {
            var path = Path.Combine(Path.GetFullPath(databaseFilePath), databaseFileName);

            Assert.IsTrue(File.Exists(path));
            var ioConnectionInfo = new IOConnectionInfo() {
                Path = path
            };

            var key = new CompositeKey();
            key.AddUserKey(new KcpPassword(databasePassword));

            this.pwDatabase = new PwDatabase();
            this.pwDatabase.Open(ioConnectionInfo, key, null);
        }

        [TearDown]
        public void Cleanup() {
            if (this.pwDatabase != null) {
                this.pwDatabase.Close();
            }
        }

        [Test]
        public void GetAllFields_ShouldReturnFieldsFromTemplates() {
            var fields = this.pwDatabase.GetAllFields();
            var expectedFields = new Collection<String>() {
                "Title",
                "UserName",
                "Password",
                "URL",
                "Notes",
                "T1Field1Name"
            };
            CollectionAssert.AreEquivalent(expectedFields, fields);
        }
    }
}
