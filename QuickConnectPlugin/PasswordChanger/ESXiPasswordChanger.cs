using System;
using VMware.Vim;

namespace QuickConnectPlugin.PasswordChanger {

    public class ESXiPasswordChanger : IPasswordChanger {

        public void ChangePassword(string host, string username, string password, string newPassword) {
            if (String.IsNullOrEmpty(host)) {
                throw new ArgumentException("Host cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(username)) {
                throw new ArgumentException("Username cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(password)) {
                throw new ArgumentException("Password cannot be null or an empty string.");
            }
            if (String.IsNullOrEmpty(newPassword)) {
                throw new ArgumentException("New password cannot be null or an empty string.");
            }

            // Login to the ESXi host.
            VimClient client = new VimClientImpl();
            client.Connect(host, null, null);
            client.Login(username, password);

            // Create the account details with the new password.
            HostPosixAccountSpec account = new HostPosixAccountSpec() {
                Id = username,
                Password = newPassword
            };

            ManagedObjectReference serviceInstanceRef = new ManagedObjectReference() {
                Type = "ServiceInstance",
                Value = "ServiceInstance"
            };

            ServiceInstance service = new ServiceInstance(client, serviceInstanceRef);
            HostLocalAccountManager accountManager = new HostLocalAccountManager(client, service.RetrieveServiceContent().AccountManager);

            // Update the account password.
            accountManager.UpdateUser(account);

            // Disconnect.
            client.Disconnect();
        }
    }
}
