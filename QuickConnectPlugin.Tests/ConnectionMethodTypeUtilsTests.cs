using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class ConnectionMethodTypeUtilsTests {

        [Test, TestCaseSource("TestCases")]
        public void GetConnectionMethodsFromString(String str, ICollection<ConnectionMethodType> expectedCollection) {
            CollectionAssert.AreEqual(expectedCollection, ConnectionMethodTypeUtils.GetConnectionMethodsFromString(str));
        }

        private static IEnumerable TestCases() {
            yield return new TestCaseData(null, new Collection<ConnectionMethodType> { });
            yield return new TestCaseData(String.Empty, new Collection<ConnectionMethodType> { });
            yield return new TestCaseData("Windows 2008 Server", new Collection<ConnectionMethodType> {
                ConnectionMethodType.RemoteDesktop,
                ConnectionMethodType.RemoteDesktopConsole
            });
            yield return new TestCaseData("Windows 2008 Server with vCenter", new Collection<ConnectionMethodType> {
                ConnectionMethodType.RemoteDesktop,
                ConnectionMethodType.RemoteDesktopConsole,
                ConnectionMethodType.vSphereClient
            });
            yield return new TestCaseData("ESXi 5.1", new Collection<ConnectionMethodType> {
                ConnectionMethodType.vSphereClient
            });
            yield return new TestCaseData("Linux", new Collection<ConnectionMethodType> {
                ConnectionMethodType.PuttySSH
            });
            yield return new TestCaseData("openSUSE 12.3", new Collection<ConnectionMethodType> {
                ConnectionMethodType.PuttySSH
            });
        }
    }
}
