namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerEx {

        void ChangePassword(IHostPwEntry hostPwEntry, string newPassword);
    }
}
