using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GingerShellPluginTest
{
    [TestClass]
    public class GingerShellPluginUnitTests
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
        public void ShellService_RunNetstatCommand()
        {
            //Arrange
            string command = "NETSTAT";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.IsNull(gingerAction.Errors);
        }


        [TestMethod]
        public void ShellService_RunIPConfigCommand()
        {
            //Arrange
            string command = "IPCONFIG";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.IsNull(gingerAction.Errors);
        }

        [TestMethod]
        public void ShellService_RunFilesListCommand()
        {
            //Arrange
            string command = "FILES_LIST";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.IsNull(gingerAction.Errors);
        }

        [TestMethod]
        public void ShellService_ValidateWindowsOS()
        {
            //Arrange
            string command = "CLEAR_SCREEN";
            ShellService service = new ShellService();
            GingerAction gingerAction = new GingerAction();

            //Act
            service.RunShell(gingerAction, command);

            //Assert
            Assert.AreEqual(gingerAction.GetOutputValue("curr_os"), "windows");
        }

    }
}
