using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QuickConnectPlugin.Commons;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;

namespace QuickConnectPlugin {

    public partial class FormPasswordChanger : Form {

        private IPasswordChangerServiceFactory pwChangerServiceFactory;
        private BatchPasswordChangerWorker pwChangerWorker;
        private IHostPwEntry hostPwEntry;

        public FormPasswordChanger(IHostPwEntry hostPwEntry, IPasswordChangerServiceFactory pwChangerServiceFactory) {
            InitializeComponent();

            this.hostPwEntry = hostPwEntry;
            this.pwChangerServiceFactory = pwChangerServiceFactory;

            this.Text = this.Text.Replace("{}", String.Format("{0}@hostname", hostPwEntry.GetUsername(), hostPwEntry.IPAddress));

            this.maskedTextBoxNewPassword.TextChanged += new EventHandler(checkPasswords);
            this.maskedTextBoxRepeatNewPassword.TextChanged += new EventHandler(checkPasswords);
            this.maskedTextBoxNewPassword.TextChanged += new EventHandler(checkControls);
            this.maskedTextBoxRepeatNewPassword.TextChanged += new EventHandler(checkControls);
            this.buttonChangePassword.Enabled = false;

            this.FormClosing += new FormClosingEventHandler(formClosing);
        }

        private void changePasswordClick(object sender, EventArgs e) {
            if (this.pwChangerWorker == null || !this.pwChangerWorker.IsRunning) {
                this.toogleControls(false);
                var passwordChangerService = this.pwChangerServiceFactory.Create(new HostTypeMapper());
                var entries = new Collection<IHostPwEntry>() { this.hostPwEntry };
                this.pwChangerWorker = new BatchPasswordChangerWorker(passwordChangerService, entries, maskedTextBoxNewPassword.Text);
                var thread = new Thread(new ThreadStart(() => runBatchPasswordChangerWorker(passwordChangerService)));
                thread.Name = "FormPasswordChangeThread";
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void runBatchPasswordChangerWorker(IPasswordChangerService passwordChangerService) {
            Debug.WriteLine("runBatchPasswordChangerWorker");
            this.pwChangerWorker.SaveDatabaseAfterEachUpdate = true;
            this.pwChangerWorker.Changed += new PasswordChangedEventHandler(batchPasswordChangerWorkerChanged);
            this.pwChangerWorker.Error += new PasswordChangeErrorEventHandler(batchPasswordChangerWorkerError);
            this.pwChangerWorker.Completed += new PasswordChangeCompletedEventHandler(batchPasswordChangerWorkerCompleted);
            this.pwChangerWorker.Run();
        }

        public void batchPasswordChangerWorkerChanged(object sender, BatchPasswordChangerEventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerChanged");
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(String.Format("Password successfully changed for user '{0}' on host '{1}'.", "Password Changer", e.HostPwEntry.GetUsername(), e.HostPwEntry.IPAddress), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        public void batchPasswordChangerWorkerError(object sender, BatchPasswordChangerErrorEventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerError");
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(String.Format("Error changing password. Exception: {0}", e.Exception), "Password Changer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        public void batchPasswordChangerWorkerCompleted(object sender, EventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerCompleted");
            this.pwChangerWorker = null;
            this.Invoke((MethodInvoker)delegate {
                this.toogleControls(true);
                this.checkControls();
            });
        }

        private void buttonShowHidePasswordClick(object sender, EventArgs e) {
            Debug.WriteLine("buttonShowHidePassword_Click");
            this.maskedTextBoxNewPassword.UseSystemPasswordChar = !this.maskedTextBoxNewPassword.UseSystemPasswordChar;
            this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar = !this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar;
            this.maskedTextBoxRepeatNewPassword.Enabled = this.maskedTextBoxNewPassword.UseSystemPasswordChar;
            if (this.maskedTextBoxNewPassword.UseSystemPasswordChar) {
                this.maskedTextBoxRepeatNewPassword.Text = this.maskedTextBoxNewPassword.Text;
            }
            else {
                this.maskedTextBoxRepeatNewPassword.Text = String.Empty;
                this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
                this.checkControls();
            }
        }

        private void checkControls(object sender, EventArgs e) {
            this.checkControls();
        }

        private void checkControls() {
            Debug.WriteLine("checkControls");
            if (this.pwChangerWorker != null && this.pwChangerWorker.IsRunning) {
                return;
            }
            if (this.maskedTextBoxNewPassword.UseSystemPasswordChar && this.passwordsMatch() ||
                !this.maskedTextBoxNewPassword.UseSystemPasswordChar) {
                this.buttonChangePassword.Enabled = true;
            }
            else {
                this.buttonChangePassword.Enabled = false;
            }
        }

        private void toogleControls(bool state) {
            this.maskedTextBoxNewPassword.Enabled = state;
            this.maskedTextBoxRepeatNewPassword.Enabled = state;
            this.buttonChangePassword.Enabled = state;
            this.buttonShowHidePassword.Enabled = state;
        }

        private bool passwordsMatch() {
            Debug.WriteLine("passwordsMatch");
            return this.maskedTextBoxNewPassword.Text.Length > 0 &&
                this.maskedTextBoxNewPassword.Text.Equals(this.maskedTextBoxRepeatNewPassword.Text);
        }

        private void checkPasswords(object sender, EventArgs e) {
            Debug.WriteLine("checkPasswords");
            if (this.maskedTextBoxNewPassword.UseSystemPasswordChar) {
                if (TextBoxUtils.HasText(this.maskedTextBoxNewPassword) && this.passwordsMatch()) {
                    this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
                }
                else if (!TextBoxUtils.HasText(this.maskedTextBoxNewPassword) && !TextBoxUtils.HasText(this.maskedTextBoxRepeatNewPassword)) {
                    this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
                }
                else {
                    this.maskedTextBoxRepeatNewPassword.BackColor = ColorTranslator.FromHtml("#FFC0C0");
                }
            }
            else {
                this.maskedTextBoxNewPassword.ResetBackColor();
                this.maskedTextBoxRepeatNewPassword.ResetBackColor();
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e) {
            Debug.WriteLine("formClosing");
            if (this.pwChangerWorker != null && this.pwChangerWorker.IsRunning) {
                MessageBox.Show(
                    "Password changing is currently running. Please wait for the current task to finish before closing the form.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                e.Cancel = true;
            }
        }
    }
}
