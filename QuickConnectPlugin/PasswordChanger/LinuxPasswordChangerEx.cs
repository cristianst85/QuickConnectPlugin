namespace QuickConnectPlugin.PasswordChanger {

    public class LinuxPasswordChangerEx : IPasswordChangerEx {

        private ILinuxPasswordChangerFactory passwordChangerFactory;

        public LinuxPasswordChangerEx(ILinuxPasswordChangerFactory passwordChangerFactory) {
            this.passwordChangerFactory = passwordChangerFactory;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            PuttyOptions options = null;
            bool success = PuttyOptions.TryParse(hostPwEntry.AdditionalOptions, out options);

            var passwordChanger = success && options.Port.HasValue ? this.passwordChangerFactory.Create(options.Port.Value) :
                                                    this.passwordChangerFactory.Create();

            passwordChanger.ChangePassword(hostPwEntry.IPAddress, hostPwEntry.GetUsername(), hostPwEntry.GetPassword(), newPassword);
        }
    }
}
