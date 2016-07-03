using NUnit.Framework;
using QuickConnectPlugin.ArgumentsFormatters;

namespace QuickConnectPlugin.Tests.ArgumentsFormatters
{
    [TestFixture]
    class WinScpArgumentsFormatterTests
    { 
        [Test]
        public void Format()
        {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry()
            {
                Username = "root",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.WinSCP);

            WinScpArgumentsFormatter argumentsFormatter = new WinScpArgumentsFormatter("WinSCP.exe");
            Assert.AreEqual("\"WinSCP.exe\" scp://root:12345678@127.0.0.1", argumentsFormatter.Format(pwEntry));
        }
    }
}
