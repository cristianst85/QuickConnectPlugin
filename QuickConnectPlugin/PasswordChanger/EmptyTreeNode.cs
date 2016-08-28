using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace QuickConnectPlugin.PasswordChanger {

    public class EmptyTreeNode : TreeNode, IPasswordChangerTreeNode {

        public EmptyTreeNode(string message)
            : base(message) {
        }

        public TreeNode Root {
            get { return this; }
            
        }

        public ICollection<IPasswordChangerHostPwEntry> GetEntries() {
            return new Collection<IPasswordChangerHostPwEntry>();
        }

        public ICollection<IPasswordChangerHostPwEntry> GetEntries(bool includeSubGroupEntries) {
            return new Collection<IPasswordChangerHostPwEntry>();
        }
    }
}
