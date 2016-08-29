using System;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerServiceWrapper : IPasswordChangerService {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChanger passwordChanger;

        public PasswordChangerServiceWrapper(IPasswordDatabase passwordDatabase, IPasswordChanger passwordChanger) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChanger = passwordChanger;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            passwordChanger.ChangePassword(hostPwEntry.IPAddress, hostPwEntry.GetUsername(), hostPwEntry.GetPassword(), newPassword);
            hostPwEntry.UpdatePassword(newPassword);
        }

        public void SaveDatabase() {
            this.passwordDatabase.Save();
        }
    }
}