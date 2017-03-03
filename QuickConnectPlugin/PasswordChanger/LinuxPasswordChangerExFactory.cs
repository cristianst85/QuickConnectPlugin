using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChangerExFactory : IPasswordChangerExGenericFactory<IPasswordChangerEx> {

        private LinuxPasswordChangerFactory factory;

        public LinuxPasswordChangerExFactory(LinuxPasswordChangerFactory factory) {
            this.factory = factory;
        }

        public IPasswordChangerEx Create() {
            return new LinuxPasswordChangerEx(factory);
        }
    }
}
