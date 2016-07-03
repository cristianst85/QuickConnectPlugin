using NUnit.Framework;
using QuickConnectPlugin.Tests;

namespace QuickConnectPlugin.ArgumentsFormatters.Tests {

    [TestFixture]
    public class PuttyArgumentsFormatterTests {

        [Test]
        public void FormatWithSSHConnection() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            FakePuttySessionFinder sessionFinder = new FakePuttySessionFinder();

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder);
            Assert.AreEqual("\"putty.exe\" -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithSSHConnectionAndSession() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "session:MySession"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            FakePuttySessionFinder sessionFinder = new FakePuttySessionFinder();
            sessionFinder.Sessions.Add("MySession");

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder);
            Assert.AreEqual("\"putty.exe\" -load \"MySession\" -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithSSHConnectionAndSessionNotFound() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "session:MySession1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            FakePuttySessionFinder sessionFinder = new FakePuttySessionFinder();

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder);
            Assert.AreEqual("\"putty.exe\" -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithSSHConnectionAndOverrideDefaultPort() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "session:MySession1;port:50000"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);
            FakePuttySessionFinder sessionFinder = new FakePuttySessionFinder();
            sessionFinder.Sessions.Add("MySession");

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder);
            Assert.AreEqual("\"putty.exe\" -load \"MySession\" -P 50000 -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithTelnetConnection() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttyTelnet);

            FakePuttySessionFinder sessionFinder = new FakePuttySessionFinder();

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder);
            Assert.AreEqual("\"putty.exe\" -telnet root@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }
    }
}
