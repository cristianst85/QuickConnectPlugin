using System;
using System.Diagnostics;
using System.Windows.Forms;
using QuickConnectPlugin.Commons;

namespace QuickConnectPlugin {

    public partial class FormAbout : Form {

        public FormAbout() {

            InitializeComponent();

            Version version = AssemblyUtils.GetVersion();

            this.labelVersion.Text = this.labelVersion.Text.Replace("{version}", String.Format("{0}.{1}", version.Major, version.Minor))
                                               .Replace("{build}", version.Build.ToString());
            this.addRevisionComponent(version);
            this.labelVersion.Text = this.labelVersion.Text.Replace("{revision}", String.Empty).TrimEnd('.');

            this.KeyDown += new KeyEventHandler(formAbout_KeyPress);
            this.richTextBoxCopyright.LinkClicked += new LinkClickedEventHandler(richTextBoxCopyright_LinkClicked);
            this.linkLabelContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContact_LinkClicked);
            this.linkLabelSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSource_LinkClicked);
            this.richTextBoxCopyright.Text = this.richTextBoxCopyright.Text.Replace("{sshNetLibVersion}", AssemblyUtils.GetVersion("Renci.SshNet").ToString());
        }

        [Conditional("DEBUG")]
        private void addRevisionComponent(Version version) {
            this.labelVersion.Text = this.labelVersion.Text.Replace("{revision}", version.Revision.ToString());
        }

        private void formAbout_KeyPress(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void richTextBoxCopyright_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void linkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(String.Format("mailto:{0}?subject=About {1} v{2}", this.linkLabelContact.Text, QuickConnectPluginExt.Title, AssemblyUtils.GetVersion()));
        }

        private void linkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/cristianst85/QuickConnectPlugin");
        }
    }
}
