using DisruptiveSoftware.Time.Clocks;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerService : IPasswordChangerService {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChangerExFactory passwordChangerFactory;
        private IHostTypeMapper hostTypeMapper;
        private IClock clock;

        public PasswordChangerService(IPasswordDatabase passwordDatabase,
            IPasswordChangerExFactory passwordChangerFactory,
            IHostTypeMapper hostTypeMapper, IClock clock) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChangerFactory = passwordChangerFactory;
            this.hostTypeMapper = hostTypeMapper;
            this.clock = clock;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            var passwordChanger = passwordChangerFactory.Create(this.hostTypeMapper.Get(hostPwEntry));
            passwordChanger.ChangePassword(hostPwEntry, newPassword);
            hostPwEntry.UpdatePassword(newPassword);
            hostPwEntry.LastModificationTime = this.clock.Now;
        }

        public void SaveDatabase() {
            this.passwordDatabase.Save();
        }
    }
}
