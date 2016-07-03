using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuickConnectPlugin.PasswordChanger {

    public class PwEntryListViewItem : ListViewItem {

        private const String PasswordMaskText = "******";

        public IPasswordChangerHostPwEntry PwEntry { get; private set; }

        public PwEntryListViewItem(IPasswordChangerHostPwEntry pwEntry, bool showPassword)
            : base(
                new List<String> {
                            pwEntry.Title,
                            pwEntry.GetUsername(),
                            showPassword ? pwEntry.GetPassword() : PasswordMaskText,
                            pwEntry.IPAddress,
                            pwEntry.HostType.ToString()

                    }.ToArray()
                ) {
            this.PwEntry = pwEntry;
        }

        public void UpdatePassword(bool showPassword) {
            this.SubItems[2].Text = showPassword ? this.PwEntry.GetPassword() : PasswordMaskText;
        }
    }
}
