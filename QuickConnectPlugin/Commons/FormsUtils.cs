using System.Windows.Forms;

namespace QuickConnectPlugin.Commons {

    internal static class FormsUtils {

        internal static bool HasText(Control control) {
            return control.Text.Length > 0;
        }

        internal static Control FindControlRecursive(Control container, string controlName)
        {
            if (container.Name == controlName)
                return container;

            foreach (Control control in container.Controls)
            {
                Control foundControl = FindControlRecursive(control, controlName);

                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }
    }
}
