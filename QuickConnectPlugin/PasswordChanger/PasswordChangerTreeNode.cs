using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using KeePassLib;

namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordChangerTreeNode : TreeNode, IPasswordChangerTreeNode {

        private PwGroup pwGroup;
        private PwDatabase pwDatabase;
        private IFieldMapper fieldMapper;

        private PasswordChangerTreeNode(PwGroup pwGroup, PwDatabase pwDatabase, IFieldMapper fieldMapper)
            : base(pwGroup.Name) {
            this.pwGroup = pwGroup;
            this.pwDatabase = pwDatabase;
            this.fieldMapper = fieldMapper;
        }

        public static PasswordChangerTreeNode Build(PwDatabase pwDatabase, IFieldMapper fieldMapper) {
            PasswordChangerTreeNode rootTreeNode = new PasswordChangerTreeNode(pwDatabase.RootGroup, pwDatabase, fieldMapper);
            build(rootTreeNode, pwDatabase.RootGroup, pwDatabase, fieldMapper);
            return rootTreeNode;
        }

        private static void build(PasswordChangerTreeNode parentTreeNode, PwGroup rootGroup, PwDatabase pwDatabase, IFieldMapper fieldMapper) {
            foreach (var group in rootGroup.Groups) {
                PasswordChangerTreeNode treeNode = new PasswordChangerTreeNode(group, pwDatabase, fieldMapper);
                parentTreeNode.Nodes.Add(treeNode);
                build(treeNode, group, pwDatabase, fieldMapper);
            }
        }

        public TreeNode Root {
            get { return this; }
        }

        public ICollection<IPasswordChangerHostPwEntry> GetEntries() {
            var entries = new Collection<IPasswordChangerHostPwEntry>();
            foreach (var pwEntry in this.pwGroup.Entries) {
                entries.Add(new PasswordChangerHostPwEntry(pwEntry, this.pwDatabase, this.fieldMapper));
            }
            return entries;
        }
    }
}