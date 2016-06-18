using NUnit.Framework;
using QuickConnectPlugin.Tests;

namespace QuickConnectPlugin.ArgumentsFormatters.Tests {

    [TestFixture]
    public class VSphereClientArgumentsFormatterTests {

        [Test]
        public void Format() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.vSphereClient);

            VSphereClientArgumentsFormatter argumentsFormatter = new VSphereClientArgumentsFormatter("VpxClient.exe");
            Assert.AreEqual("\"VpxClient.exe\" -s 127.0.0.1 -u root -p 12345678", argumentsFormatter.Format(pwEntry));
        }
    }
}
