namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerGenericFactory<T> where T : IPasswordChanger {

        T Create();
    }
}
