using System.Collections.Generic;
using System.Windows.Forms;

namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerTreeNode {

        TreeNode Root { get; }

        ICollection<IPasswordChangerHostPwEntry> GetEntries();
    }
}
