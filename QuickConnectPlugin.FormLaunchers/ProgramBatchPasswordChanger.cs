using System;
using System.IO;
using System.Windows.Forms;
using DisruptiveSoftware.Time.Clocks;
using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Tests;

namespace QuickConnectPlugin.FormLaunchers {

    static class ProgramBatchPasswordChanger {

        private static readonly string databasePath = Path.GetFullPath(@"..\..\..\QuickConnectPlugin.Tests.Resources\sample.kdbx");
        private static readonly string databasePassword = "12345678";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ioConnectionInfo = new IOConnectionInfo() {
                Path = databasePath
            };

            var key = new CompositeKey();
            key.AddUserKey(new KcpPassword(databasePassword));

            var pwDatabase = new PwDatabase();
            pwDatabase.Open(ioConnectionInfo, key, null);

            var fieldMapper = new InMemoryFieldMapper() {
                HostAddress = "IP Address",
                ConnectionMethod = "OS"
            };

            IPasswordChangerTreeNode treeNode = PasswordChangerTreeNode.Build(pwDatabase, fieldMapper);

            var pwChangerServiceFactory = new PasswordChangerServiceFactory(
                new PasswordDatabase(pwDatabase),
                new FakePasswordChangerExFactoryThatThrowsException(),
                new SystemClock()
            );

            var formBatchPasswordChanger = new FormBatchPasswordChanger(treeNode, pwChangerServiceFactory);
            Application.Run(formBatchPasswordChanger);
        }
    }
}
