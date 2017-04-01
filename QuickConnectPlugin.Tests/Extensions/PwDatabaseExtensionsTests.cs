using System;
using System.Collections.ObjectModel;
using System.IO;
using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using NUnit.Framework;
using QuickConnectPlugin.Extensions;

namespace QuickConnectPlugin.Tests.Extensions {

    [TestFixture("sample-templates.kdbx")]
    public class PwDatabaseExtensionsTests {

        private readonly string databaseFilePath = Path.GetFullPath(@"..\..\..\QuickConnectPlugin.Tests.Resources\");
        private readonly string databasePassword = "12345678";

        private String databaseFileName;
        private PwDatabase pwDatabase;

        public PwDatabaseExtensionsTests(String dbName) {
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
        public void GetCustomFieldsFromKPTemplates() {
            var templatesFields = this.pwDatabase.GetCustomFieldsFromKPTemplates();
            var expectedFields = new Collection<String>() {
                "T1Field1Name",
                "T1Field2Name",
                "T2Field1Name",
                "T2Field2Name"  
            };
            CollectionAssert.AreEquivalent(expectedFields, templatesFields);
        }

        [Test]
        public void GetAllFields() {
            var fields = this.pwDatabase.GetAllFields();
            var expectedFields = new Collection<String>() {
                "Title",
                "UserName",
                "Password",
                "URL",
                "Notes",
                "T3Field1Name",
                "E1Field1Name",
            };
            CollectionAssert.AreEquivalent(expectedFields, fields);
        }

        [Test]
        public void GetAllFieldsAndIncludeCustomFieldsFromKPTemplates() {
            var fields = this.pwDatabase.GetAllFields(true);
            var expectedFields = new Collection<String>() {
                "Title",
                "UserName",
                "Password",
                "URL",
                "Notes",
                "T1Field1Name",
                "T1Field2Name",
                "T2Field1Name",
                "T2Field2Name",
                "T3Field1Name",
                "E1Field1Name"
            };
            CollectionAssert.AreEquivalent(expectedFields, fields);
        }
    }
}
