using System;
using System.Diagnostics;
using System.Threading;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.BatchPasswordChangerFormLaucher {

    public class FakePasswordChanger : IPasswordChanger {

        private HostType hostType;

        public FakePasswordChanger(HostType hostType) {
            this.hostType = hostType;
        }

        public void ChangePassword(string host, string username, string password, string newPassword) {
            Debug.WriteLine(String.Format("{0}.ChangePassword()", this.GetType().Name));
            Debug.WriteLine(String.Format("hostType: {0}", hostType));
            Debug.WriteLine(String.Format("host: {0}", host));
            Debug.WriteLine(String.Format("username: {0}", username));
            Debug.WriteLine(String.Format("password: {0}", password));
            Debug.WriteLine(String.Format("newPassword: {0}", newPassword));
            Thread.Sleep(2000);
        }
    }
}
