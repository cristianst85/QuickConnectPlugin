using QuickConnectPlugin.PasswordChanger.Services;

namespace QuickConnectPlugin.Tests.PasswordChanger.Services {

    public class MockPasswordChangerService : IPasswordChangerService {

        public int ChangePasswordCount { get; private set; }
        public int SaveDatabaseCount { get; private set; }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            this.ChangePasswordCount++;
        }

        public void SaveDatabase() {
            this.SaveDatabaseCount++;
        }
    }
}
