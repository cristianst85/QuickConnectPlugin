namespace QuickConnectPlugin {
    partial class FormPasswordChanger {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonShowHidePassword = new System.Windows.Forms.Button();
            this.maskedTextBoxRepeatNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.labelRepeatNewPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonShowHidePassword);
            this.groupBox.Controls.Add(this.maskedTextBoxRepeatNewPassword);
            this.groupBox.Controls.Add(this.maskedTextBoxNewPassword);
            this.groupBox.Controls.Add(this.labelRepeatNewPassword);
            this.groupBox.Controls.Add(this.labelNewPassword);
            this.groupBox.Location = new System.Drawing.Point(11, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(327, 79);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // buttonShowHidePassword
            // 
            this.buttonShowHidePassword.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonShowHidePassword.Location = new System.Drawing.Point(280, 19);
            this.buttonShowHidePassword.Name = "buttonShowHidePassword";
            this.buttonShowHidePassword.Size = new System.Drawing.Size(34, 20);
            this.buttonShowHidePassword.TabIndex = 12;
            this.buttonShowHidePassword.Text = "···";
            this.buttonShowHidePassword.UseVisualStyleBackColor = true;
            this.buttonShowHidePassword.Click += new System.EventHandler(this.buttonShowHidePasswordClick);
            // 
            // maskedTextBoxRepeatNewPassword
            // 
            this.maskedTextBoxRepeatNewPassword.Location = new System.Drawing.Point(131, 45);
            this.maskedTextBoxRepeatNewPassword.Name = "maskedTextBoxRepeatNewPassword";
            this.maskedTextBoxRepeatNewPassword.Size = new System.Drawing.Size(143, 20);
            this.maskedTextBoxRepeatNewPassword.TabIndex = 7;
            this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar = true;
            // 
            // maskedTextBoxNewPassword
            // 
            this.maskedTextBoxNewPassword.Location = new System.Drawing.Point(131, 19);
            this.maskedTextBoxNewPassword.Name = "maskedTextBoxNewPassword";
            this.maskedTextBoxNewPassword.Size = new System.Drawing.Size(143, 20);
            this.maskedTextBoxNewPassword.TabIndex = 6;
            this.maskedTextBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // labelRepeatNewPassword
            // 
            this.labelRepeatNewPassword.AutoSize = true;
            this.labelRepeatNewPassword.Location = new System.Drawing.Point(9, 48);
            this.labelRepeatNewPassword.Name = "labelRepeatNewPassword";
            this.labelRepeatNewPassword.Size = new System.Drawing.Size(116, 13);
            this.labelRepeatNewPassword.TabIndex = 5;
            this.labelRepeatNewPassword.Text = "Repeat new password:";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(45, 22);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(80, 13);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "New password:";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(119, 97);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(110, 25);
            this.buttonChangePassword.TabIndex = 6;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.changePasswordClick);
            // 
            // FormPasswordChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 131);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPasswordChanger";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password ({})";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonShowHidePassword;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRepeatNewPassword;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNewPassword;
        private System.Windows.Forms.Label labelRepeatNewPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Button buttonChangePassword;
    }
}