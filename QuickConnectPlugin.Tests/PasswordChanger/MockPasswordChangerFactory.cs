using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    public class MockPasswordChangerFactory : IPasswordChangerFactory {

        public MockPasswordChanger PasswordChanger { get; private set; }

        public IPasswordChanger Create(HostType hostType) {
            this.PasswordChanger = new MockPasswordChanger();
            return this.PasswordChanger;
        }
    }
}
