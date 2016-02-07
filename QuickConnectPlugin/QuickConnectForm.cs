using System;
using System.Diagnostics;
using System.Windows.Forms;
using QuickConnectPlugin.Commons;

namespace QuickConnectPlugin {

    public partial class QuickConnectForm : Form {

        public QuickConnectForm() {

            InitializeComponent();

            Version version = AssemblyUtils.GetVersion();

            this.label2.Text = this.label2.Text.Replace("{version}", String.Format("{0}.{1}", version.Major, version.Minor))
                                               .Replace("{build}", version.Build.ToString());
            this.addRevisionComponent(version);
            this.label2.Text = this.label2.Text.Replace("{revision}", String.Empty).TrimEnd('.');
            this.richTextBoxCopyright.LinkClicked += new LinkClickedEventHandler(richTextBoxCopyright_LinkClicked);
            this.linkLabelContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContact_LinkClicked);
            this.linkLabelSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
        }

        [Conditional("DEBUG")]
        private void addRevisionComponent(Version version) {
            this.label2.Text = this.label2.Text.Replace("{revision}", version.Revision.ToString());
        }

        private void richTextBoxCopyright_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void linkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(String.Format("mailto:{0}?subject=About {1} v{2}", this.linkLabelContact.Text, QuickConnectPluginExt.Title, AssemblyUtils.GetVersion()));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/cristianst85/QuickConnectPlugin");
        }
    }
}
