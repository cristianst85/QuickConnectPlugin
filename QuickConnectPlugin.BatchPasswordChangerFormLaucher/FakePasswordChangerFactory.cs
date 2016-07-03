using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.BatchPasswordChangerFormLaucher {

    public class FakePasswordChangerFactory : IPasswordChangerFactory {

        public IPasswordChanger Create(HostType hostType) {
            return new FakePasswordChanger(hostType);
        }
    }
}
