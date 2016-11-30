namespace QuickConnectPlugin.PasswordChanger {

    public class WindowsNativePasswordChangerFactory : IWindowsNativePasswordChangerFactory {

        public WindowsNativePasswordChangerFactory() {
        }

        public IPasswordChanger Create() {
            return new WindowsNativePasswordChanger(WindowsADSIProvider.None);
        }

        public IPasswordChanger Create(WindowsADSIProvider provider) {
            return new WindowsNativePasswordChanger(provider);
        }
    }
}
