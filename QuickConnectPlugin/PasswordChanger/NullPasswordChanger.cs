namespace QuickConnectPlugin.PasswordChanger {

    public class NullPasswordChanger : IPasswordChanger {

        public void ChangePassword(string host, string username, string password, string newPassword) {
            ; // No-op.
        }
    }
}
