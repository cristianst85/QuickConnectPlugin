using System;
using System.Collections.Generic;

namespace QuickConnectPlugin.PasswordChanger {

    public class DictionaryPasswordChangerExFactory : IPasswordChangerExFactory {

        public IDictionary<HostType, IPasswordChangerExGenericFactory<IPasswordChangerEx>> Factories { get; private set; }

        public DictionaryPasswordChangerExFactory() {
            this.Factories = new Dictionary<HostType, IPasswordChangerExGenericFactory<IPasswordChangerEx>>();
        }

        public IPasswordChangerEx Create(HostType hostType) {
            if (this.Factories.ContainsKey(hostType)) {
                return this.Factories[hostType].Create();
            }
            else {
                throw new NotSupportedException(String.Format("{0} '{1}' is not supported.", typeof(HostType), hostType));
            }
        }
    }
}
