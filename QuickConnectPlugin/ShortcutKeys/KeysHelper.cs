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
        private static ICollection<Keys> KeePassDefaultShortcuts = new Collection<Keys>
        {
            // Entry context menu.
            Keys.Control | Keys.A,
            Keys.Control | Keys.B,
            Keys.Control | Keys.C,
            Keys.Control | Keys.I,
            Keys.Control | Keys.K,
            Keys.Control | Keys.V,
            Keys.Control | Keys.U,
            Keys.Control | Keys.Shift | Keys.U,
            Keys.Control | Keys.Shift | Keys.C,
            Keys.Control | Keys.Shift | Keys.V,
            Keys.Control | Keys.G,
            Keys.Delete,
            Keys.Return,
            Keys.Alt | Keys.Home,
            Keys.Alt | Keys.Up,
            Keys.Alt | Keys.Down,
            Keys.Alt | Keys.End,
            // Menus.
            Keys.Alt | Keys.F,
            Keys.Alt | Keys.E,
            Keys.Alt | Keys.V,
            Keys.Alt | Keys.T,
            Keys.Alt | Keys.H,
            // Menu functions.
            Keys.Control | Keys.N,
            Keys.Control | Keys.W,
            Keys.Control | Keys.O,
            Keys.Control | Keys.Shift | Keys.O,
            Keys.Control | Keys.S,
            Keys.Control | Keys.P,
            Keys.Control | Keys.R,
            Keys.Control | Keys.Shift | Keys.R,
            Keys.Control | Keys.L,
            Keys.Control | Keys.Q,
            Keys.Control | Keys.I,
            Keys.Control | Keys.F,
            Keys.Control | Keys.Shift | Keys.F,
            Keys.Control | Keys.E,
            Keys.F1
        };

        private static ICollection<Keys> KeePassPluginsShortcuts = new Collection<Keys>
        {
            Keys.F9 // KPEnhancedListview
        };

        private static ICollection<Keys> KeePassHotKeys() {
            return new Collection<Keys>()
            {
                (Keys)Program.Config.Integration.HotKeyEntryMenu,
                (Keys)Program.Config.Integration.HotKeyShowWindow,
                (Keys)Program.Config.Integration.HotKeySelectedAutoType,
                (Keys)Program.Config.Integration.HotKeyGlobalAutoType
            };
        }

        public static bool TryParse(string keyString, out Keys key)
        {
            key = Keys.None;

            if (String.IsNullOrEmpty(keyString))
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
            return 
                KeePassDefaultShortcuts.Contains(key) || 
                KeePassHotKeys().Contains(key);
        }

        public static void UnregisterKeePassHotKeys()
        {
            Keys kAutoTypeKey = (Keys)Program.Config.Integration.HotKeyGlobalAutoType;
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.AutoType);
            Keys kAutoTypeSelKey = (Keys)Program.Config.Integration.HotKeySelectedAutoType;
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.AutoTypeSelected);
            Keys kShowWindowKey = (Keys)Program.Config.Integration.HotKeyShowWindow;
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.ShowWindow);
            Keys kEntryMenuKey = (Keys)Program.Config.Integration.HotKeyEntryMenu;
            HotKeyManager.UnregisterHotKey(AppDefs.GlobalHotKeyId.EntryMenu);
        }

        public static void RegisterKeePassHotKeys()
        {
            Keys kAutoTypeKey = (Keys)Program.Config.Integration.HotKeyGlobalAutoType;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.AutoType, kAutoTypeKey);
            Keys kAutoTypeSelKey = (Keys)Program.Config.Integration.HotKeySelectedAutoType;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.AutoTypeSelected, kAutoTypeSelKey);
            Keys kShowWindowKey = (Keys)Program.Config.Integration.HotKeyShowWindow;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.ShowWindow, kShowWindowKey);
            Keys kEntryMenuKey = (Keys)Program.Config.Integration.HotKeyEntryMenu;
            HotKeyManager.RegisterHotKey(AppDefs.GlobalHotKeyId.EntryMenu, kEntryMenuKey);
        }
    }
}