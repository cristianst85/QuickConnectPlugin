using System;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerService : IPasswordChangerService {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChangerExFactory passwordChangerFactory;
        private IHostTypeMapper hostTypeMapper;

        public PasswordChangerService(IPasswordDatabase passwordDatabase,
            IPasswordChangerExFactory passwordChangerFactory,
            IHostTypeMapper hostTypeMapper) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChangerFactory = passwordChangerFactory;
            this.hostTypeMapper = hostTypeMapper;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, String newPassword) {
            var passwordChanger = passwordChangerFactory.Create(this.hostTypeMapper.Get(hostPwEntry));
            passwordChanger.ChangePassword(hostPwEntry, newPassword);
            hostPwEntry.UpdatePassword(newPassword);
        }

        public void SaveDatabase() {
            this.passwordDatabase.Save();
        }
    }
}
