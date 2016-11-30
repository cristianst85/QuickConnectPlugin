namespace QuickConnectPlugin.PasswordChanger {

    public class WindowsNativePasswordChangerEx : IPasswordChangerEx {

        private IWindowsNativePasswordChangerFactory passwordChangerFactory;

        public WindowsNativePasswordChangerEx(IWindowsNativePasswordChangerFactory passwordChangerFactory) {
            this.passwordChangerFactory = passwordChangerFactory;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            WindowsPasswordChangerOptions options = null;
            bool success = WindowsPasswordChangerOptions.TryParse(hostPwEntry.AdditionalOptions, out options);

            var passwordChanger = passwordChangerFactory.Create(success ? options.Provider.Value : WindowsADSIProvider.None);

            passwordChanger.ChangePassword(hostPwEntry.IPAddress, hostPwEntry.GetUsername(), hostPwEntry.GetPassword(), newPassword);
        }
    }
}
