
namespace QuickConnectPlugin.PasswordChanger {

    public interface IWindowsNativePasswordChangerFactory : IPasswordChangerGenericFactory<IPasswordChanger> {

        IPasswordChanger Create(WindowsADSIProvider provider);
    }
}
