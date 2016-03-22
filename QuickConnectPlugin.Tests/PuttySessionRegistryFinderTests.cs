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

        [Test]
        public void FindAllThatContainsWord() {
            RegistryPuttySessionFinder finder = new RegistryPuttySessionFinder();
            CollectionAssert.IsNotEmpty(finder.Find("root"));
        }
    }
}
