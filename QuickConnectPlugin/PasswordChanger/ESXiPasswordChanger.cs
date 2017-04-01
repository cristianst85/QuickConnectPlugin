using System;
using System.IO;
using System.Reflection;

namespace QuickConnectPlugin.PasswordChanger {

    public class ESXiPasswordChanger : IPasswordChanger {

        private BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance;
        private Assembly assembly = null;

        public ESXiPasswordChanger() {
            var path = QuickConnectUtils.GetVSpherePowerCLIPath();
            if (!String.IsNullOrEmpty(path)) {
                path = Path.Combine(path, "VMware.Vim.dll");
            }
            else {
                throw new Exception("VMware vSphere PowerCLI is not installed.");
            }
            this.assembly = Assembly.LoadFile(path);
        }

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

            try {
                // Login to the ESXi host.
                var client = Activator.CreateInstance(assembly.GetType("VMware.Vim.VimClientImpl"));

                client.GetType().InvokeMember("Connect", flags, null, client, new object[] { host, null, null });
                client.GetType().InvokeMember("Login", flags, null, client, new object[] { username, password });

                // Create the account details with the new password.
                var account = Activator.CreateInstance(assembly.GetType("VMware.Vim.HostPosixAccountSpec"));
                account.GetType().GetProperty("Id").SetValue(account, username, null);
                account.GetType().GetProperty("Password").SetValue(account, newPassword, null);

                var serviceInstanceRef = Activator.CreateInstance(assembly.GetType("VMware.Vim.ManagedObjectReference"));
                serviceInstanceRef.GetType().GetProperty("Type").SetValue(serviceInstanceRef, "ServiceInstance", null);
                serviceInstanceRef.GetType().GetProperty("Value").SetValue(serviceInstanceRef, "ServiceInstance", null);

                var service = Activator.CreateInstance(assembly.GetType("VMware.Vim.ServiceInstance"), new object[] { client, serviceInstanceRef });
                var serviceContent = service.GetType().InvokeMember("RetrieveServiceContent", flags, null, service, new object[] { });

                var accountManager = serviceContent.GetType().GetProperty("AccountManager").GetValue(serviceContent, null);
                var hostLocalAccountManager = Activator.CreateInstance(assembly.GetType("VMware.Vim.HostLocalAccountManager"), new object[] { client, accountManager });

                // Update the account password.
                hostLocalAccountManager.GetType().InvokeMember("UpdateUser", flags, null, hostLocalAccountManager, new object[] { account });

                // Disconnect.
                client.GetType().InvokeMember("Disconnect", flags, null, client, new object[] { });
            }
            catch (TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }
    }
}