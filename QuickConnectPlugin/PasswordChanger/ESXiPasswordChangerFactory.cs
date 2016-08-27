using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class ESXiPasswordChangerFactory : IPasswordChangerGenericFactory<IPasswordChanger> {

        public IPasswordChanger Create() {
            return new ESXiPasswordChanger();
        }
    }
}
