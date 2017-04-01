using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordChangerFactory : IPasswordChangerFactory {

        private PsPasswdWrapper wrapper;

        public PasswordChangerFactory(PsPasswdWrapper psPasswdWrapper) {
            this.wrapper = psPasswdWrapper;
        }

        public IPasswordChanger Create(HostType hostType) {
            if (hostType == HostType.ESXi) {
                return new ESXiPasswordChanger();
            }
            else if (hostType == HostType.Windows) {
                return new WindowsPasswordChanger(wrapper);
            }
            else {
                throw new NotSupportedException(String.Format("{0} '{1}' is not supported.", typeof(HostType), hostType));
            }
        }
    }
}
