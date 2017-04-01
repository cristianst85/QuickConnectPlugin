using System;

namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChanger {

        void ChangePassword(String host, String username, String password, String newPassword);

    }
}
