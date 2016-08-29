using System;
using System.Collections.Generic;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public interface IPasswordChangerServiceFactory {

        IPasswordChangerService Create(IHostTypeMapper hostTypeMapper);

        ICollection<HostType> GetSupported();

    }
}
