using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace QuickConnectPlugin.PasswordChanger {

    public class WindowsNativePasswordChanger : IPasswordChanger {

        private WindowsADSIProvider provider;

        public WindowsNativePasswordChanger(WindowsADSIProvider provider) {
            if (provider != WindowsADSIProvider.WinNT && provider != WindowsADSIProvider.None) {
                throw new ArgumentException(String.Format("Provider '{0}' is not supported.", provider.ToString()));
            }
            this.provider = provider;
        }

        public void ChangePassword(string host, string username, string password, string newPassword) {
            if (this.provider == WindowsADSIProvider.None) {

                ContextType contexType = ContextType.Machine;
                IdentityType identityType = IdentityType.SamAccountName;

                if (username.Contains("@")) {
                    contexType = ContextType.Domain;
                    identityType = IdentityType.UserPrincipalName;
                    username = username.Substring(0, username.IndexOf("@"));
                };

                PrincipalContext principalContext = new PrincipalContext(contexType, host, username, password);
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, identityType, username);
                userPrincipal.SetPassword(newPassword);
                userPrincipal.Save();
            }
            else if (provider == WindowsADSIProvider.WinNT) {
                using (var localDirectory = new DirectoryEntry(String.Format("{0}://{1}", provider, host))) {
                    var users = localDirectory.Children;
                    using (var user = users.Find(username)) {
                        user.Invoke("ChangePassword", password, newPassword);
                    }
                }
            }
            else {
                throw new NotSupportedException(String.Format("Provider '{0}' is not supported.", provider.ToString()));
            }
        }
    }
}
