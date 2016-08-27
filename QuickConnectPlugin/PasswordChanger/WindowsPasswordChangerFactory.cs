using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class WindowsPasswordChangerFactory : IPasswordChangerGenericFactory<IPasswordChanger> {

        private PsPasswdWrapper wrapper;

        public WindowsPasswordChangerFactory(PsPasswdWrapper wrapper) {
            this.wrapper = wrapper;
        }

        public IPasswordChanger Create() {
            return new WindowsPasswordChanger(this.wrapper);
        }
    }
}
