using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Text;

namespace GingerShellPluginTest
{
    [TestClass]
    public class GingerShellPluginUnitTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // before every test
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //after every test
        }


        [TestMethod]
        public void TestGingerShell_RunNetstatCommand()
        {
            //Arrange
            string command = "NETSTAT";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.AreEqual(gingerAction.Errors, null);
        }


        [TestMethod]
        public void TestGingerShell_RunIPConfigCommand()
        {
            //Arrange
            string command = "IPCONFIG";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.AreEqual(gingerAction.Errors, null);
        }

        

    }
}
