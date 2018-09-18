using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace GingerShellPluginTest
{
    [TestClass]
    public class GingerShellPluginUnitTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            //EmptyTempTestsFolder();
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

        // create a test folder 
        // develop few TC's 

        [TestMethod]
        public void TestGingerShell_CheckFilesCount()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFile("") ;
            tempFolder = tempFolder + "\\ShellTests";
            string tempFileName = tempFolder + "\\ShellTest1.txt";

            //Act
            CreateTempFileContents(tempFileName);
            //int fileCount = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(fileName)).Length; 
            int fileCount = System.IO.Directory.GetFiles(tempFolder).Length;

            //Assert
            Assert.AreEqual(fileCount, 1);
        }




        private void CreateTempFileContents(string fileName)
        {
            // Create a string array that consists of three lines.
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(fileName, lines);
        }

        private static void EmptyTempTestsFolder()
        {
            string tempFolder = TestResources.GetTempFile("") + "\\ShellTests";
            if (System.IO.Directory.Exists(tempFolder))
            {
                System.IO.DirectoryInfo directory = new DirectoryInfo(tempFolder);
                foreach (System.IO.FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(tempFolder);
            }
        }


    }
}
