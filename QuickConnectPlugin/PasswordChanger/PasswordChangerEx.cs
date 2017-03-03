namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordChangerEx : IPasswordChangerEx {

        private IPasswordChanger passwordChanger;

        public PasswordChangerEx(IPasswordChanger passwordChanger) {
            this.passwordChanger = passwordChanger;
        }

        public void ChangePassword(IHostPwEntry hostPwEntry, string newPassword) {
            this.passwordChanger.ChangePassword(
                hostPwEntry.IPAddress,
                hostPwEntry.GetUsername(),
                hostPwEntry.GetPassword(),
                newPassword
            );
        }
    }
}
