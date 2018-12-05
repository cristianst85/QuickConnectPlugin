using System;
using System.Collections;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class PuttyOptionsTests {

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("some text with no valid arguments")]
        public void TryParseReturnsFalse(String optionsString) {
            PuttyOptions options;
            Assert.IsFalse(PuttyOptions.TryParse(optionsString, out options));
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
            Assert.IsTrue(PuttyOptions.TryParse(optionsString, out options));
            Assert.AreEqual(expectedSessionName, options.SessionName);
            Assert.AreEqual(expectedPort, options.Port);
        }

        [TestCaseSource("TestCases")]
        public void TryParse(String puttyOptionsString, PuttyOptions expectedPuttyOptions) {
            PuttyOptions puttyOptions;
            Assert.IsTrue(PuttyOptions.TryParse(puttyOptionsString, out puttyOptions));
            Assert.AreEqual(expectedPuttyOptions, puttyOptions);
        }

        private static IEnumerable TestCases() {
            yield return new TestCaseData(
                "session:",
                new PuttyOptions() { SessionName = "" }
            );
            yield return new TestCaseData(
                "session:\"Default Settings\";port:2672;key:\"C:\\KeyFiles\\PrivateKey.ppk\"",
                new PuttyOptions() {
                    Port = 2672,
                    SessionName = "Default Settings",
                    KeyFilePath = "C:\\KeyFiles\\PrivateKey.ppk",
                }
            );

            yield return new TestCaseData(
                "session:\"Default Settings\";port:2672;key:C:\\KeyFiles\\PrivateKey.ppk",
                new PuttyOptions() {
                    Port = 2672,
                    SessionName = "Default Settings",
                    KeyFilePath = "C:\\KeyFiles\\PrivateKey.ppk",
                }
            )
            .SetDescription("No double quotes in key file path.");

            yield return new TestCaseData(
               "session: \"Default Settings\"; port: 2672; key: \"C:\\KeyFiles\\PrivateKey.ppk\"",
               new PuttyOptions() {
                   Port = 2672,
                   SessionName = "Default Settings",
                   KeyFilePath = "C:\\KeyFiles\\PrivateKey.ppk",
               }
           )
           .SetDescription("Added some blank spaces.");

            yield return new TestCaseData(
                "ssh;key:\"PrivateKey.ppk\"",
                new PuttyOptions() {
                    KeyFilePath = "PrivateKey.ppk"
                }
            );

            yield return new TestCaseData(
                "ssh;command:-pw pass",
                new PuttyOptions() {
                    Command = "-pw pass"
                }
            );
        }
    }
}
