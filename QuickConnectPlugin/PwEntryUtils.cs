using System;
using KeePass.Util.Spr;
using KeePassLib;

namespace QuickConnectPlugin {

    public static class PwEntryUtils {

        public static string ReadCompiledSafeString(PwDatabase database, PwEntry pwEntry, String stringName) {
            return SprEngine.Compile(pwEntry.Strings.GetSafe(stringName).ReadString(), new SprContext(pwEntry, database, SprCompileFlags.All));
        }
    }
}
