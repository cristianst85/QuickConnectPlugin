using System;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.FormLaunchers {

    public class FakePasswordChangerExFactoryThatThrowsException : IPasswordChangerExFactory {

        public IPasswordChangerEx Create(HostType hostType) {
            throw new NotSupportedException(hostType.ToString());
        }
    }
}
