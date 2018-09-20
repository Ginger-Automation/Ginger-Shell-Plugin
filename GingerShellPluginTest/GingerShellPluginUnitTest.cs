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
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Called once when the test assembly is loaded
            // We provide the assembly to GingerTestHelper.TestResources so it can locate the 'TestResources' folder path
            // DO NOT DELETE
            TestResources.Assembly = Assembly.GetExecutingAssembly();
        }

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
        public void TestGingerShell_RunShell()
        {
            //Arrange
            ShellService service = new ShellService();
            GingerAction GA = new GingerAction();

            //Act
            service.RunShell(GA, "IP_CONFIG");

            //Assert
            Assert.AreEqual(null, GA.Errors);
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


        private void CreateTempFileContents(string fileName)
        {
            // Create a string array that consists of three lines.
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(fileName, lines);
        }


    }
}
