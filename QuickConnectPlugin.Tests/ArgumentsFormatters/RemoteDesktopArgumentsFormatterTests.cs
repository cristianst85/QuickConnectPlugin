using System;
using NUnit.Framework;
using QuickConnectPlugin.Tests;

namespace QuickConnectPlugin.ArgumentsFormatters.Tests {

    [TestFixture]
    public class RemoteDesktopArgumentsFormatterTests {

        [TestCase]
        public void Format() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter();
            Assert.AreEqual(String.Format("\"{0}\" /v:127.0.0.1", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithUseConsole() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter() {
                UseConsole = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /v:127.0.0.1 /admin", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithOlderVersionConsole() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter() {
                UseConsole = true,
                IsOlderVersion = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /v:127.0.0.1 /console", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithFullScreen() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter() {
                FullScreen = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /v:127.0.0.1 /f", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }
    }
}
