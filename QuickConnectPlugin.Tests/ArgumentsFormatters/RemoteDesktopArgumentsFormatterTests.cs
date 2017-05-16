using System;
using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;
using QuickConnectPlugin.FormLauchers;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters {

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
            InMemoryQuickConnectPluginSettings pluginSettings = new InMemoryQuickConnectPluginSettings();
            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter(pluginSettings);
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
            InMemoryQuickConnectPluginSettings pluginSettings = new InMemoryQuickConnectPluginSettings();
            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter(pluginSettings) {
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
            InMemoryQuickConnectPluginSettings pluginSettings = new InMemoryQuickConnectPluginSettings();
            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter(pluginSettings) {
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
            InMemoryQuickConnectPluginSettings pluginSettings = new InMemoryQuickConnectPluginSettings();
            RemoteDesktopArgumentsFormatter argumentsFormatter = new RemoteDesktopArgumentsFormatter(pluginSettings) {
                FullScreen = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /v:127.0.0.1 /f", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }
    }
}
