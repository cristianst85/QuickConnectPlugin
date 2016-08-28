using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.FormLauchers {

    public class FakePasswordChangerFactory : IPasswordChangerFactory {

        private int threadSleepDuration;

        public FakePasswordChangerFactory() {
            this.threadSleepDuration = 2000;
        }

        public FakePasswordChangerFactory(int threadSleepDuration) {
            this.threadSleepDuration = threadSleepDuration;
        }

        public IPasswordChanger Create(HostType hostType) {
            return new FakePasswordChanger(hostType) { ThreadSleepDuration = this.threadSleepDuration };
        }
    }
}
