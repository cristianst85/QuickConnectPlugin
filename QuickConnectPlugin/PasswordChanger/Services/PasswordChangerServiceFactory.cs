using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using QuickConnectPlugin.Commons;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerServiceFactory : IPasswordChangerServiceFactory {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChangerFactory passwordChangerFactory;

        public PasswordChangerServiceFactory(IPasswordDatabase passwordDatabase, IPasswordChangerFactory passwordChangerFactory) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChangerFactory = passwordChangerFactory;
        }

        public IPasswordChangerService Create(IHostTypeMapper hostTypeMapper) {
            return new PasswordChangerService(this.passwordDatabase, this.passwordChangerFactory, hostTypeMapper);
        }

        public ICollection<HostType> GetSupported() {
            var results = new Collection<HostType>();
            foreach (var hostType in EnumUtils.EnumToList<HostType>()) {
                try {
                    this.passwordChangerFactory.Create(hostType);
                    results.Add(hostType);
                }
                catch (NotSupportedException) {
                }
            }
            return results;
        }
    }
}
