using NUnit.Framework;
using System;

namespace QuickConnectPlugin.Tests.Commons
{
    [TestFixture]
    public class AssemblyUtilsTests {

        [TestCase("Renci.SshNet")]
        public void AssemblyResolverFromResources(string resourceName) {
            var assembly = QuickConnectPlugin.Commons.AssemblyUtils.AssemblyResolverFromResources(null, new ResolveEventArgs(resourceName));
            Assert.That(assembly, Is.Not.Null);
            Assert.That(assembly.GetName().Name, Is.EqualTo(resourceName));
        }

        [TestCase("FakeResource")]
        public void AssemblyResolverFromResourcesReturnsNull(string resourceName) {
            Assert.That(QuickConnectPlugin.Commons.AssemblyUtils.AssemblyResolverFromResources(null, new ResolveEventArgs(resourceName)), Is.Null);
        }
    }
}
