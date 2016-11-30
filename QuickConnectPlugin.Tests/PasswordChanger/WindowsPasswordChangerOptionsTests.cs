using System;
using System.Collections;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class WindowsPasswordChangerOptionsTests {

        [TestCase(null)]
        [TestCase("")]
        [TestCase("rdp")]
        public void TryParseReturnsFalse(String optionsString) {
            WindowsPasswordChangerOptions options;
            Assert.IsFalse(WindowsPasswordChangerOptions.TryParse(optionsString, out options));
            Assert.That(options.Provider, Is.Null);
        }

        [TestCaseSource("TestCases")]
        public void TryParse(String optionsString, WindowsPasswordChangerOptions expectedOptions) {
            WindowsPasswordChangerOptions options;
            Assert.IsTrue(WindowsPasswordChangerOptions.TryParse(optionsString, out options));
            Assert.AreEqual(expectedOptions, options);
        }

        private static IEnumerable TestCases() {
            yield return new TestCaseData(
                "provider:WinNT",
                new WindowsPasswordChangerOptions() { Provider = WindowsADSIProvider.WinNT }
            );
            yield return new TestCaseData(
                "rdp; provider:WinNT",
                new WindowsPasswordChangerOptions() { Provider = WindowsADSIProvider.WinNT }
            );
            yield return new TestCaseData(
               "rdp; provider: WinNT",
               new WindowsPasswordChangerOptions() { Provider = WindowsADSIProvider.WinNT }
            );
        }
    }
}
