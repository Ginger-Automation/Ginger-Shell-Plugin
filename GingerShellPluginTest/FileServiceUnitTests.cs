using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GingerShellPluginTest
{
    [TestClass]
    public class FileServiceUnitTests
    {
        private static string testFolderName = "FileServiceTests";

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
        public void TestGingerFileService_CheckFileExists()
        {
            //Arrange
            string tempFileName = TestResources.GetTempFile(testFolderName + "\\FileServiceFileExists.txt");
            FileService service = new FileService();
            GingerAction gingerAct = new GingerAction();

            //Act
            CreateTempFileContents(tempFileName);
            service.FileExists(gingerAct, tempFileName);

            //Assert
            Assert.IsNull(gingerAct.Errors);
        }


        [TestMethod]
        public void TestGingerFileService_CheckFileNotExists()
        {
            //Arrange
            FileService service = new FileService();
            GingerAction gingerAct = new GingerAction();
            string tempFileName = "TestFileName.txt";

            //Act
            service.FileExists(gingerAct, tempFileName);

            //Assert
            Assert.AreEqual(gingerAct.Errors, null);
        }

        [TestMethod]
        public void TestGingerFileService_CheckFilesCount()
        {
            //Arrange
            string tempFolder = TestResources.GetTempFile("") + "\\" + testFolderName;
            string tempFileName = tempFolder + "\\FileServiceTest1.txt";

            //Act
            CreateTempFileContents(tempFileName);
            //int fileCount = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(tempFileName)).Length; 
            int fileCount = System.IO.Directory.GetFiles(tempFolder).Length;

            //Assert
            Assert.IsTrue(fileCount > 0);
        }

        [TestMethod]
        public void TestGingerFileService_RunFileInfoCommand()
        {
            //Arrange
            FileService service = new FileService();
            GingerAction gingerAct = new GingerAction();
            string tempFileName = TestResources.GetTempFile(testFolderName + "\\FileServiceFileInfo.txt");

            //Act
            CreateTempFileContents(tempFileName);
            service.FileInfo(gingerAct, tempFileName);

            //Assert
            Assert.AreEqual(gingerAct.GetOutputValue("FileInfo"), "True");
        }



        private void CreateTempFileContents(string fileName)
        {
            // Create a string array that consists of three lines.
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(fileName, lines);
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

    }

}
