using DisruptiveSoftware.Time.Clocks;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerServiceWrapper : IPasswordChangerService {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChanger passwordChanger;
        private IClock clock;

        public PasswordChangerServiceWrapper(IPasswordDatabase passwordDatabase, IPasswordChanger passwordChanger, IClock clock) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChanger = passwordChanger;
            this.clock = clock;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            passwordChanger.ChangePassword(hostPwEntry.IPAddress, hostPwEntry.GetUsername(), hostPwEntry.GetPassword(), newPassword);
            hostPwEntry.UpdatePassword(newPassword);
            hostPwEntry.LastModificationTime = this.clock.Now;
        }

        public void SaveDatabase() {
            this.passwordDatabase.Save();
        }
    }
}