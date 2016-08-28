using System;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.FormLauchers {

    public class NotSupportedPasswordChangerFactory : IPasswordChangerFactory {

        public IPasswordChanger Create(HostType hostType) {
            throw new NotSupportedException(hostType.ToString());
        }
    }
}
