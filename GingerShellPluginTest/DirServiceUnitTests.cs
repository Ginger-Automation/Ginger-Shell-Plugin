using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GingerShellPluginTest
{
    [TestClass]
    public class DirServiceUnitTests
    {
        private static string testFolderName = "DirServiceTests";

        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            EmptyTempFolder();
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
        public void DirService_RunDirInfoCommand()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFile(testFolderName);

            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();

            //Act
            dirService.DirInfo(gingerAct, tempFolder);

            //Assert
            Assert.IsNotNull(gingerAct.GetOutputValue("DirInfo_Root"));
            Assert.AreEqual(gingerAct.GetOutputValue("DirInfo_Name"), testFolderName);
        }

        [TestMethod]
        public void DirService_CheckDirExists()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();

            //Act
            dirService.DirExists(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual(gingerAct.GetOutputValue("DirExists"), "True");
        }


        [TestMethod]
        public void DirService_DirList()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();
            
            string tempFile1 = TestResources.GetTempFile(testFolderName + "\\test1.txt");
            string tempFile2 = TestResources.GetTempFile(testFolderName + "\\test2.txt");

            //Act
            CreateTempFileContents(tempFile1);
            CreateTempFileContents(tempFile2);
            dirService.DirList(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual(gingerAct.GetOutputValue("DirList"), "True");
        }

        [TestMethod]
        public void DirService_DirListFileCount()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();

            string tempFile1 = TestResources.GetTempFile(testFolderName + "\\test1.txt");
            string tempFile2 = TestResources.GetTempFile(testFolderName + "\\test2.txt");

            //Act
            CreateTempFileContents(tempFile1);
            CreateTempFileContents(tempFile2);
            dirService.DirList(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual(gingerAct.GetOutputValue("FileCount"), "2");
        }

        private static void EmptyTempFolder()
        {
            string tempFolder = TestResources.GetTempFile("") + "\\" + testFolderName;
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
