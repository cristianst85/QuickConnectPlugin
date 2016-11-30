using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin {

    public class WindowsNativePasswordChangerExFactory : IPasswordChangerExGenericFactory<IPasswordChangerEx> {

        private WindowsNativePasswordChangerFactory factory;

        public WindowsNativePasswordChangerExFactory(WindowsNativePasswordChangerFactory factory) {
            this.factory = factory;
        }

        public IPasswordChangerEx Create() {
            return new WindowsNativePasswordChangerEx(factory);
        }
    }
}