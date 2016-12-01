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
            Assert.AreEqual("\"WinSCP.exe\" scp://root:12345678@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }

        [Test]
        public void FormatWithCustomPort() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1",
                AdditionalOptions = "port:50000"
            };

            pwEntry.ConnectionMethods.Add(ConnectionMethodType.WinSCP);

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root:12345678@127.0.0.1:50000", argumentsFormatter.Format(pwEntry));
        }
    }
}
