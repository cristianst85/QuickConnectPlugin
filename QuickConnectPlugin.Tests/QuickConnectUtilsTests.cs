using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class QuickConnectUtilsTests {

        [Test]
        public void IsOlderRemoteDesktopConnectionVersion() {
            Assert.IsFalse(QuickConnectUtils.IsOlderRemoteDesktopConnectionVersion());
        }

        [Test]
        public void GetVSphereClientPath() {
            Assert.AreEqual(@"C:\Program Files (x86)\VMware\Infrastructure\Virtual Infrastructure Client\Launcher\VpxClient.exe", QuickConnectUtils.GetVSphereClientPath());
        }
    }
}
