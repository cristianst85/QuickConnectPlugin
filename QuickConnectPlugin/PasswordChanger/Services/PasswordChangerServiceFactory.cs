using System;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerServiceFactory : IPasswordChangerServiceFactory {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChangerFactory passwordChangerFactory;

        public PasswordChangerServiceFactory(IPasswordDatabase passwordDatabase, IPasswordChangerFactory passwordChangerFactory) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChangerFactory = passwordChangerFactory;
        }

        public IPasswordChangerService Create(IHostTypeMapper hostTypeMapper) {
            return new PasswordChangerService(this.passwordDatabase, this.passwordChangerFactory, hostTypeMapper);
        }
    }
}
