using System;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters {

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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder, true);
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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder, true);
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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder, true);
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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder, true);
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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", sessionFinder, true);
            Assert.AreEqual("\"putty.exe\" -telnet root@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithKeyFile() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "key:\"C:\\Key Files\\PrivateKey.ppk\""
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, true);
            Assert.AreEqual("\"putty.exe\" -i \"C:\\Key Files\\PrivateKey.ppk\" -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithPortFromHostAddress() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, true);
            Assert.AreEqual("\"putty.exe\" -P 2222 -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithPortFromHostAddressTakePrecedence() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222",
                AdditionalOptions = "session:MySession1;port:50000"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>() { "MySession" });

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, true);
            Assert.AreEqual("\"putty.exe\" -load \"MySession\" -P 2222 -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithNoPassword() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry()
            {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());
            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, false);
            Assert.AreEqual("\"putty.exe\" -P 2222 -ssh root@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithCommand() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222",
                AdditionalOptions = "ssh;command:-L 5555:127.0.0.1:5432"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());
            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, true);
            Assert.AreEqual("\"putty.exe\" -P 2222 -ssh root@127.0.0.1 -pw \"12345678\" -L 5555:127.0.0.1:5432", argumentsFormatter.Format(pwEntry));
        }

        [Description("Password argument present in command takes precedence")]
        [TestCase(true)]
        [TestCase(false)]
        public void FormatWithCommandContainingOnlyThePassword(bool appendPassword) {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222",
                AdditionalOptions = "ssh;command:-pw \"123456\""
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());
            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, appendPassword);
            Assert.AreEqual("\"putty.exe\" -P 2222 -ssh root@127.0.0.1 -pw \"123456\"", argumentsFormatter.Format(pwEntry));
        }

        [Description("Password argument present in command takes precedence")]
        [TestCase(true)]
        [TestCase(false)]
        public void FormatWithCommandContainingPassword(bool appendPassword) {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222",
                AdditionalOptions = "ssh;command:-L 5555:127.0.0.1:5432 -pw \"123456\""
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.PuttySSH);

            var mock = new Mock<IPuttySessionFinder>();
            mock.Setup(m => m.Find(It.IsAny<String>())).Returns(new Collection<String>());
            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object, appendPassword);
            Assert.AreEqual("\"putty.exe\" -P 2222 -ssh root@127.0.0.1 -L 5555:127.0.0.1:5432 -pw \"123456\"", argumentsFormatter.Format(pwEntry));
        }
    }
}
