using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChangerFactory : IPasswordChangerGenericFactory<IPasswordChanger> {

        public IPasswordChanger Create() {
            return new LinuxPasswordChanger();
        }
    }
}
