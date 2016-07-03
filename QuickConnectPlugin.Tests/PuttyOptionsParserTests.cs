using System;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class PuttyOptionsParserTests {

        [TestCase(null)]
        [TestCase("")]
        public void TryParseReturnsFalse(String optionsString) {
            PuttyOptions options;
            Assert.IsFalse(PuttyOptionsParser.TryParse(optionsString, out options));
        }

        [TestCase("session:", "", null)]
        [TestCase("session:\"\"", "", null)]
        [TestCase("session:MySession", "MySession", null)]
        [TestCase("session:My Session", "My Session", null)]
        [TestCase("session:\"MySession\"", "MySession", null)]
        [TestCase("session:\"My Session\"", "My Session", null)]
        [TestCase("session:\"My Session\"; Telnet", "My Session", null, Description = "Use the same field to specify the session name and connection method")]
        [TestCase("telnet; session:\"My Session\"", "My Session", null, Description = "Use the same field to specify the session name and connection method")]
        [TestCase("session:\"%cygterm @ yellow/dark_blue\"", "%cygterm @ yellow/dark_blue", null, Description = "Test case / GitHub Issue #2")]
        [TestCase("ssh;port:50000;session:\"my session\"", "my session", 50000)]
        public void TryParse(String optionsString, String expectedSessionName, int? expectedPort) {
            PuttyOptions options;
            Assert.IsTrue(PuttyOptionsParser.TryParse(optionsString, out options));
            Assert.AreEqual(expectedSessionName, options.SessionName);
            Assert.AreEqual(expectedPort, options.Port);
        }
    }
}
