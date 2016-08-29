using System;

namespace QuickConnectPlugin.PasswordChanger.Services {

    public interface IPasswordChangerService {

        void ChangePassword(IHostPwEntry hostPwEntry, String newPassword);

        void SaveDatabase();
    }
}
