using System;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class PuttyOptionsParserTests {

        [TestCase(null)]
        [TestCase("")]
        [TestCase("The quick brown fox...")]
        [TestCase(";")]
        [TestCase("session")]
        public void TryParseReturnsFalse(String optionsString) {
            PuttyOptions options;
            Assert.IsFalse(PuttyOptionsParser.TryParse(optionsString, out options));
        }

        [TestCase("session:", "")]
        [TestCase("session:\"\"", "")]
        [TestCase("session:MySession", "MySession")]
        [TestCase("session:My Session", "My Session")]
        [TestCase("session:\"MySession\"", "MySession")]
        [TestCase("session:\"My Session\"", "My Session")]
        [TestCase("session:\"My Session\"; Telnet", "My Session", Description = "Use the same field to specify the session name and connection method")]
        [TestCase("telnet; session:\"My Session\"", "My Session", Description = "Use the same field to specify the session name and connection method")]
        public void TryParse(String optionsString, String expectedSessionName) {
            PuttyOptions options;
            Assert.IsTrue(PuttyOptionsParser.TryParse(optionsString, out options));
            Assert.AreEqual(expectedSessionName, options.SessionName);
        }
    }
}
