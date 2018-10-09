using System;
using System.Windows.Forms;
using DisruptiveSoftware.Time.Clocks;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Tests;
using QuickConnectPlugin.Tests.PasswordChanger;

namespace QuickConnectPlugin.FormLaunchers {

    static class ProgramPasswordChanger {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var pwDatabase = new FakePasswordDatabase();
            var hostPwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "pass",
                IPAddress = "host",
            };
            hostPwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);
            var pwChanger = new FakePasswordChanger(HostType.Windows) { ThreadSleepDuration = 20000 };
            var pwChangerService = new PasswordChangerServiceWrapper(pwDatabase, pwChanger, new SystemClock());
            var formPasswordChange = new FormPasswordChanger(hostPwEntry, pwChangerService);
            Application.Run(formPasswordChange);
        }
    }
}
