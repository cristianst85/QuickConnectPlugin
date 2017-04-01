using System;
using System.Collections.Generic;

namespace QuickConnectPlugin.PasswordChanger {

    public class DictionaryPasswordChangerFactory : IPasswordChangerFactory {

        public IDictionary<HostType, IPasswordChangerGenericFactory<IPasswordChanger>> Factories { get; private set; }

        public DictionaryPasswordChangerFactory() {
            this.Factories = new Dictionary<HostType, IPasswordChangerGenericFactory<IPasswordChanger>>();
        }

        public IPasswordChanger Create(HostType hostType) {
            if (this.Factories.ContainsKey(hostType)) {
                return this.Factories[hostType].Create();
            }
            else {
                throw new NotSupportedException(String.Format("{0} '{1}' is not supported.", typeof(HostType), hostType));
            }
        }
    }
}
