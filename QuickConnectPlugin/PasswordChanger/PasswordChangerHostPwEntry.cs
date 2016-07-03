using KeePassLib;

namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordChangerHostPwEntry : HostPwEntry, IPasswordChangerHostPwEntry {

        public PasswordChangerHostPwEntry(PwEntry pwEntry, PwDatabase pwDatabase, IFieldMapper fieldMapper)
            : base(pwEntry, pwDatabase, fieldMapper) {
        }

        public new string Title {
            get { return base.Title; }
        }

        public HostType HostType {
            get {
                return new HostTypeMapper().Get(this);
            }
        }
    }
}
