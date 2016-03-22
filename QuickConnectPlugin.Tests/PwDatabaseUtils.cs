using System;
using KeePassLib;

namespace QuickConnectPlugin.Tests {

    public static class PwDatabaseUtils {

        public static PwEntry FindEntryByTitle(PwDatabase pwDatabase, String title, bool recursive) {
            foreach (PwEntry entry in pwDatabase.RootGroup.GetEntries(recursive).CloneShallowToList()) {
                if (entry.Strings.Get("Title").ReadString().Equals(title)) {
                    return entry;
                }
            }
            return null;
        }
    }
}
