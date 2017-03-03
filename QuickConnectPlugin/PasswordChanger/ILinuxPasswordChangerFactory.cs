
namespace QuickConnectPlugin.PasswordChanger {

    public interface ILinuxPasswordChangerFactory : IPasswordChangerGenericFactory<IPasswordChanger> {

        IPasswordChanger Create(int port);
    }
}
