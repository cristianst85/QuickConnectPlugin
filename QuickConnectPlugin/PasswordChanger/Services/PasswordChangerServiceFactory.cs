using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DisruptiveSoftware.Time.Clocks;
using QuickConnectPlugin.Commons;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public class PasswordChangerServiceFactory : IPasswordChangerServiceFactory {

        private IPasswordDatabase passwordDatabase;
        private IPasswordChangerExFactory passwordChangerFactory;
        private IClock clock;

        public PasswordChangerServiceFactory(IPasswordDatabase passwordDatabase, IPasswordChangerExFactory passwordChangerFactory, IClock clock) {
            this.passwordDatabase = passwordDatabase;
            this.passwordChangerFactory = passwordChangerFactory;
            this.clock = clock;
        }

        public IPasswordChangerService Create(IHostTypeMapper hostTypeMapper) {
            return new PasswordChangerService(this.passwordDatabase, this.passwordChangerFactory, hostTypeMapper, this.clock);
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
