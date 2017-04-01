using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using QuickConnectPlugin.Tests.Services;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class PuttySessionRegistryFinderTests {

        [Test, TestCaseSource("TestCases")]
        public void FindAll(ICollection<String> sessions, ICollection<String> expected, String regexPattern) {
            RegistryPuttySessionFinder sessionFinder = new RegistryPuttySessionFinder(new InMemoryRegistryService(sessions));
            CollectionAssert.AreEquivalent(expected, sessionFinder.Find(regexPattern));
        }

        static object[] TestCases = {
            new object[] {
                new Collection<String>(),
                new Collection<String>(),
                ".*"
            },
            new object[] {
                    new Collection<String>() { "session1@localhost", "session2@localhost" },
                    new Collection<String>() { "session1@localhost", "session2@localhost" },
                    ".*"
            },
            new object[] { 
                    new Collection<String>() { "root@localhost", "user@localhost" },
                    new Collection<String>() { "root@localhost" },
                    "root"
            },
            new object[] {
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                "%cygterm @ yellow/dark_blue"
            },
            new object[] {
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                "dark_blue"
            },
            new object[] {
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                new Collection<String>() { "%cygterm @ yellow/dark_blue" },
                ".*dark_blue.*"
            }
        };
    }
}
