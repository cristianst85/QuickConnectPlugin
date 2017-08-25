using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters {

    [TestFixture]
    public class WinScpArgumentsFormatterTests {

        [Test]
        public void Format() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root:\"12345678\"@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithCustomPort() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "port:50000"
            };

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root:\"12345678\"@127.0.0.1:50000", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithKeyFile() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "key:\"C:\\Key Files\\PrivateKey.ppk\""
            };

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root@127.0.0.1 -privatekey=\"C:\\Key Files\\PrivateKey.ppk\" -passphrase=\"12345678\"", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithPortFromHostAddress() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1:2222"
            };

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root:\"12345678\"@127.0.0.1:2222", argumentsFormatter.Format(pwEntry));
        }
    }
}
