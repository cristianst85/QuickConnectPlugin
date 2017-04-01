using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin.Tests.PasswordChanger {

    [TestFixture]
    public class HostTypeMapperTests {

        [TestCase]
        public void Get() {
            var hostTypeConverter = new Mock<IHostTypeConverter>();
            hostTypeConverter.Setup(x => x.Convert(ConnectionMethodType.vSphereClient)).Returns(HostType.ESXi);
            hostTypeConverter.Setup(x => x.Convert(ConnectionMethodType.PuttySSH)).Returns(HostType.Linux);

            var hostPwEntry = new Mock<IHostPwEntry>();
            hostPwEntry.SetupGet(x => x.HasConnectionMethods).Returns(true);
            hostPwEntry.SetupGet(x => x.ConnectionMethods).Returns(
                new Collection<ConnectionMethodType>() { 
                    ConnectionMethodType.vSphereClient,
                    ConnectionMethodType.PuttySSH
                }
            );

            var hostTypeMapper = new HostTypeMapper(hostTypeConverter.Object);
            Assert.AreEqual(HostType.ESXi, hostTypeMapper.Get(hostPwEntry.Object));
        }
    }
}
