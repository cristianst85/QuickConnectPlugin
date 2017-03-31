
namespace QuickConnectPlugin.PasswordChanger {
    
    public interface ILinuxPasswordChanger : IPasswordChanger {

        int? SshPort { get; set; }
    }
}
