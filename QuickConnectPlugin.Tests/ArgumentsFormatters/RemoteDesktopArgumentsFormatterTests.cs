using System;
using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters
{
    [TestFixture]
    public class RemoteDesktopArgumentsFormatterTests
    {
        [TestCase]
        public void Format()
        {
            var pwEntry = new InMemoryHostPwEntry()
            {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };

            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            var argumentsFormatter = new RemoteDesktopArgumentsFormatter();

            Assert.AreEqual(string.Format("\"{0}\" /v:127.0.0.1", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithUseFullScreen()
        {
            var pwEntry = new InMemoryHostPwEntry()
            {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };

            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            var argumentsFormatter = new RemoteDesktopArgumentsFormatter()
            {
                UseFullScreen = true
            };

            Assert.AreEqual(string.Format("\"{0}\" /v:127.0.0.1 /f", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithUseConsole()
        {
            var pwEntry = new InMemoryHostPwEntry()
            {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };

            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            var argumentsFormatter = new RemoteDesktopArgumentsFormatter()
            {
                UseConsole = true
            };

            Assert.AreEqual(string.Format("\"{0}\" /v:127.0.0.1 /console", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithUseAdmin()
        {
            var pwEntry = new InMemoryHostPwEntry()
            {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };

            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            var argumentsFormatter = new RemoteDesktopArgumentsFormatter()
            {
                UseAdmin = true
            };

            Assert.AreEqual(string.Format("\"{0}\" /v:127.0.0.1 /admin", RemoteDesktopArgumentsFormatter.RemoteDesktopClientPath), argumentsFormatter.Format(pwEntry));
        }
    }
}
