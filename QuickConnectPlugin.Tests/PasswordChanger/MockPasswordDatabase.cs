using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    public class MockPasswordDatabase : IPasswordDatabase {

        public int SaveCount { get; private set; }

        public void Save() {
            this.SaveCount++;
        }
    }
}
