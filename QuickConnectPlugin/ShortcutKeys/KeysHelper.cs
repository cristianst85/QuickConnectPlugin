using KeePass;
using KeePass.App;
using KeePass.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace QuickConnectPlugin.ShortcutKeys
{
    public class KeysHelper
    {
        private static readonly ICollection<Keys> KeePassDefaultShortcuts = new Collection<Keys>
        {
            // File menu functions.
            Keys.Control | Keys.N,
            Keys.Control | Keys.O,
            Keys.Control | Keys.Shift | Keys.O,
            Keys.Control | Keys.W,
            Keys.Control | Keys.S,
            Keys.Control | Keys.P,
            Keys.Control | Keys.R,
            Keys.Control | Keys.Shift | Keys.R,
            Keys.Control | Keys.L,
            Keys.Control | Keys.Q,

            // Entry menu functions.
            Keys.Control | Keys.B,
            Keys.Control | Keys.C,
            Keys.Control | Keys.U,
            Keys.Control | Keys.Shift | Keys.U,
            Keys.Control | Keys.T,
            Keys.Control | Keys.Shift | Keys.T,
            Keys.Control | Keys.V,
            Keys.Control | Keys.I,
            Keys.Enter,
            Keys.Return,
            Keys.Control | Keys.K,
            Keys.Control | Keys.A,
            Keys.Control | Keys.Shift | Keys.C,
            Keys.Control | Keys.Shift | Keys.V,

            // Find menu functions.
            Keys.F3,
            Keys.Control | Keys.F,
            Keys.Control | Keys.Shift | Keys.F,
            Keys.Control | Keys.G,

            // Misc.
            Keys.Control | Keys.J,
            Keys.Control | Keys.H,
            Keys.F1,
            Keys.Escape,
            Keys.Control | Keys.E,
            Keys.Control | Keys.Tab,
            Keys.Control | Keys.Shift | Keys.Tab,

            // Main group tree / main entry list commands.
            Keys.Delete,
            Keys.Shift | Keys.Delete,
            Keys.Alt | Keys.Home,
            Keys.Alt | Keys.Up,
            Keys.Alt | Keys.Down,
            Keys.Alt | Keys.End,
            Keys.Control | Keys.Shift | Keys.F5,
            Keys.Control | Keys.Shift | Keys.F6,
            Keys.Control | Keys.Shift | Keys.F7,
            Keys.Control | Keys.Shift | Keys.F8,
            Keys.Control | Keys.D,
            Keys.Control | Keys.Shift | Keys.D,

            // Group menu functions.
            Keys.Control | Keys.Multiply, // Ctrl + * (numeric keypad)
            Keys.Control | Keys.Divide, // Ctrl + / (numeric keypad)
            Keys.Control | Keys.Shift | Keys.C,
            Keys.Control | Keys.Shift | Keys.V,
            Keys.Control | Keys.Shift | Keys.P,

            // Menus.
            Keys.Alt | Keys.F,
            Keys.Alt | Keys.G,
            Keys.Alt | Keys.E,
            Keys.Alt | Keys.I,
            Keys.Alt | Keys.V,
            Keys.Alt | Keys.T,
            Keys.Alt | Keys.H
        };

        private static readonly ICollection<Keys> KeePassGlobalHotKeys = new Collection<Keys>
        {
            (Keys)Program.Config.Integration.HotKeyEntryMenu,
            (Keys)Program.Config.Integration.HotKeyShowWindow,
            (Keys)Program.Config.Integration.HotKeySelectedAutoType,
            (Keys)Program.Config.Integration.HotKeyGlobalAutoTypePassword,
            (Keys)Program.Config.Integration.HotKeyGlobalAutoType
        };

        private static readonly ICollection<Keys> KeePassPluginsShortcuts = new Collection<Keys>
        {
            Keys.F9 // KPEnhancedListview
        };

        public static bool TryParse(string keyString, out Keys key)
        {
            key = Keys.None;

            if (string.IsNullOrEmpty(keyString))
            {
                return true;
            }

            try
            {
                key = (Keys)Enum.Parse(typeof(Keys), keyString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ConflictsWithKeePassShortcutKeys(Keys key)
        {
            return KeePassDefaultShortcuts.Contains(key) || KeePassGlobalHotKeys.Contains(key);
        }

        public static void UnregisterKeePassGlobalHotKeys()
        {
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.EntryMenu);
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.ShowWindow);
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.AutoType);
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.AutoTypeSelected);
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.AutoTypePassword);
        }

        public static void RegisterKeePassGlobalHotKeys()
        {
            var kEntryMenuHotKey = (Keys)Program.Config.Integration.HotKeyEntryMenu;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.EntryMenu, kEntryMenuHotKey);

            var kShowWindowHotKey = (Keys)Program.Config.Integration.HotKeyShowWindow;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.ShowWindow, kShowWindowHotKey);

            var kGlobalAutoTypeHotKey = (Keys)Program.Config.Integration.HotKeyGlobalAutoType;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.AutoType, kGlobalAutoTypeHotKey);

            var kAutoTypeSelectedHotKey = (Keys)Program.Config.Integration.HotKeySelectedAutoType;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.AutoTypeSelected, kAutoTypeSelectedHotKey);

            var kAutoTypePasswordHotKey = (Keys)Program.Config.Integration.HotKeyGlobalAutoTypePassword;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.AutoTypePassword, kAutoTypePasswordHotKey);
        }
    }
}
