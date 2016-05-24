using NUnit.Framework;
using QuickConnectPlugin.Services;

namespace QuickConnectPlugin.Tests.Services {

    [Ignore]
    [TestFixture]
    public class WindowsRegistryServiceTests {

        [Test]
        public void GetPuttySessions() {
            var registryService = new WindowsRegistryService();
            var sessions = registryService.GetPuttySessions();
            CollectionAssert.Contains(sessions, "keepass@test");
            CollectionAssert.Contains(sessions, "%cygterm @ yellow/dark_blue", "Test case / GitHub Issue #2 (sessions name contains special characters).");
        }
    }
}
