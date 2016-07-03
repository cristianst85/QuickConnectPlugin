using System.Windows.Forms;

namespace QuickConnectPlugin.Commons {

    public static class TextBoxUtils {

        public static bool HasText(Control control) {
            return control.Text.Length > 0;
        }
    }
}
