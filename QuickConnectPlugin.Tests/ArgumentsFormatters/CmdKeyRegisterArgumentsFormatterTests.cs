using System;
using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters {

    [TestFixture]
    public class CmdKeyRegisterArgumentsFormatterTests {

        [TestCase]
        public void Format() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            CmdKeyRegisterArgumentsFormatter argumentsFormatter = new CmdKeyRegisterArgumentsFormatter();
            Assert.AreEqual("/generic:TERMSRV/127.0.0.1 /user:admin /pass:12345678", argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithPath() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            CmdKeyRegisterArgumentsFormatter argumentsFormatter = new CmdKeyRegisterArgumentsFormatter() {
                IncludePath = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /generic:TERMSRV/127.0.0.1 /user:admin /pass:12345678", CmdKeyRegisterArgumentsFormatter.CmdKeyPath), argumentsFormatter.Format(pwEntry));
        }
    }
}