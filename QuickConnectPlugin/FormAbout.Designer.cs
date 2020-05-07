namespace QuickConnectPlugin {
    partial class FormAbout {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxCopyright = new System.Windows.Forms.RichTextBox();
            this.linkLabelSource = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelPluginName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabelContact = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Released under GNU GPLv2 or later.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Portions copyright:";
            // 
            // richTextBoxCopyright
            // 
            this.richTextBoxCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.richTextBoxCopyright.Location = new System.Drawing.Point(24, 163);
            this.richTextBoxCopyright.Name = "richTextBoxCopyright";
            this.richTextBoxCopyright.ReadOnly = true;
            this.richTextBoxCopyright.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxCopyright.Size = new System.Drawing.Size(255, 58);
            this.richTextBoxCopyright.TabIndex = 18;
            this.richTextBoxCopyright.Text = resources.GetString("richTextBoxCopyright.Text");
            // 
            // linkLabelSource
            // 
            this.linkLabelSource.AutoSize = true;
            this.linkLabelSource.Location = new System.Drawing.Point(21, 88);
            this.linkLabelSource.Name = "linkLabelSource";
            this.linkLabelSource.Size = new System.Drawing.Size(113, 13);
            this.linkLabelSource.TabIndex = 14;
            this.linkLabelSource.TabStop = true;
            this.linkLabelSource.Text = "GitHub project source.";
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(21, 35);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(259, 15);
            this.labelVersion.TabIndex = 11;
            this.labelVersion.Text = "Version {version}";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPluginName
            // 
            this.labelPluginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPluginName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPluginName.Location = new System.Drawing.Point(21, 20);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(259, 15);
            this.labelPluginName.TabIndex = 10;
            this.labelPluginName.Text = "QuickConnect";
            this.labelPluginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Contact:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelContact
            // 
            this.linkLabelContact.AutoSize = true;
            this.linkLabelContact.Location = new System.Drawing.Point(21, 123);
            this.linkLabelContact.Name = "linkLabelContact";
            this.linkLabelContact.Size = new System.Drawing.Size(138, 13);
            this.linkLabelContact.TabIndex = 15;
            this.linkLabelContact.TabStop = true;
            this.linkLabelContact.Text = "cristianstoica85@gmail.com";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Copyright (c) 2016-2020, Cristian Stoica.\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 236);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxCopyright);
            this.Controls.Add(this.linkLabelSource);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelPluginName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabelContact);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About {title}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxCopyright;
        private System.Windows.Forms.LinkLabel linkLabelSource;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelPluginName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabelContact;
        private System.Windows.Forms.Label label3;


    }
}