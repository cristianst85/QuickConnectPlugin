namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerExGenericFactory<T> where T : IPasswordChangerEx {

        T Create();
    }
}
