using KeePassLib;
using KeePassLib.Interfaces;

namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordDatabase : IPasswordDatabase {

        public PwDatabase PwDatabase { get; private set; }

        public PasswordDatabase(PwDatabase pwDatabase) {
            this.PwDatabase = pwDatabase;
        }

        public void Save() {
            IStatusLogger logger = new NullStatusLogger();
            this.PwDatabase.Save(logger);
            logger.EndLogging();
        }
    }
}
