using System;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    public class MockPasswordChanger : IPasswordChanger {

        public String Host { get; private set; }
        public String Username { get; private set; }
        public String Password { get; private set; }
        public String NewPassword { get; private set; }

        public int ChangePasswordCount { get; private set; }

        public void ChangePassword(string host, string username, string password, string newPassword) {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.NewPassword = newPassword;
            this.ChangePasswordCount++;
        }
    }
}
