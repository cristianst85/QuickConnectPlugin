using QuickConnectPlugin.PasswordChanger;
using System.Diagnostics;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    public class FakePasswordDatabase : IPasswordDatabase {

        public void Save() {
            Debug.WriteLine(string.Format("{0}.Save() method was called.", this.GetType().Name));
        }
    }
}
