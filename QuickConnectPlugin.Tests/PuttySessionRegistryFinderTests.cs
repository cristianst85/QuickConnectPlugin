using NUnit.Framework;
using System;

namespace QuickConnectPlugin.Tests {

    [Ignore]
    [TestFixture]
    public class PuttySessionRegistryFinderTests {

        [Test]
        public void FindAll() {
            RegistryPuttySessionFinder finder = new RegistryPuttySessionFinder();
            CollectionAssert.IsNotEmpty(finder.Find(".*"));
        }

        [TestCase("root")]
        [TestCase("keepass")]
        public void FindAllThatContainsWord(String pattern) {
            RegistryPuttySessionFinder finder = new RegistryPuttySessionFinder();
            CollectionAssert.IsNotEmpty(finder.Find(pattern));
        }
    }
}
