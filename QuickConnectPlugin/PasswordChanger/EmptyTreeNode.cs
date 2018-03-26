using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace QuickConnectPlugin.PasswordChanger {

    [Serializable]
    public class EmptyTreeNode : TreeNode, IPasswordChangerTreeNode {

        protected EmptyTreeNode(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) {
        }

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
