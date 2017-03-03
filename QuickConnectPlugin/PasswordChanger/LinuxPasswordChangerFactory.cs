using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChangerFactory : ILinuxPasswordChangerFactory {

        public IPasswordChanger Create() {
            return new LinuxPasswordChanger();
        }

        public IPasswordChanger Create(int port) {
            return new LinuxPasswordChanger() { SshPort = port };
        }
    }
}
