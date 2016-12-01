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

            PuttyArgumentsFormatter argumentsFormatter = new PuttyArgumentsFormatter("putty.exe", mock.Object);
            Assert.AreEqual("\"putty.exe\" -i \"C:\\Key Files\\PrivateKey.ppk\" -ssh root@127.0.0.1 -pw \"12345678\"", argumentsFormatter.Format(pwEntry));
        }
    }
}
