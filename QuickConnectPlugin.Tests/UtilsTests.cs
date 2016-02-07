using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class UtilsTests {

        [Test]
        public void IsOlderRemoteDesktopConnectionVersion() {
            Assert.IsFalse(Utils.IsOlderRemoteDesktopConnectionVersion());
        }

        [Test]
        public void GetVMwareVSphereClientPath() {
            Assert.AreEqual(@"C:\Program Files (x86)\VMware\Infrastructure\Virtual Infrastructure Client\Launcher\VpxClient.exe", Utils.GetVMwareVSphereClientPath());
        }
    }
}
