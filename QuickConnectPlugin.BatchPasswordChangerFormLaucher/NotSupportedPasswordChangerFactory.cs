using System;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.BatchPasswordChangerFormLaucher {

    public class NotSupportedPasswordChangerFactory : IPasswordChangerFactory {

        public IPasswordChanger Create(HostType hostType) {
            throw new NotSupportedException(hostType.ToString());
        }
    }
}
