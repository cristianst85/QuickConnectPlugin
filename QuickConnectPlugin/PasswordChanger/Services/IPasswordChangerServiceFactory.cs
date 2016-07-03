using System;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public interface IPasswordChangerServiceFactory {

        IPasswordChangerService Create(IHostTypeMapper hostTypeMapper);
    }
}
