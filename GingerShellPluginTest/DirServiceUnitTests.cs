﻿using Amdocs.Ginger.Plugin.Core;
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
        public void DirService_CheckDirExists()
        {
            //Arrange
            string tempFolder = TestResources.getGingerUnitTesterTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();

            //Act
            dirService.DirExists(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual("True", gingerAct.Output["DirExists"], "DirExists=True");
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
            Assert.IsNotNull(gingerAct.Output["DirInfo_Root"], "DirInfo_Root is not null");
            Assert.AreEqual(testFolderName, gingerAct.Output["DirInfo_Name"] );
        }

        [TestMethod]
        public void DirService_DirList()
        {
            //Arrange
            string tempFolder = TestResources.getGingerUnitTesterTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();
            
            string tempFile1 = Path.Combine(tempFolder, "test1.txt");
            string tempFile2 = Path.Combine(tempFolder, "test2.txt");

            //Act
            CreateTempFileContents(tempFile1);
            CreateTempFileContents(tempFile2);
            dirService.DirList(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual("True", gingerAct.Output["DirList"]);
        }

        [TestMethod]
        public void DirService_DirListFileCount()
        {
            //Arrange
            string tempFolder = TestResources.getGingerUnitTesterTempFolder(testFolderName);
            DirService dirService = new DirService();
            GingerAction gingerAct = new GingerAction();

            string tempFile1 = Path.Combine(tempFolder, "test1.txt");
            string tempFile2 = Path.Combine(tempFolder, "test2.txt");

            //Act
            CreateTempFileContents(tempFile1);
            CreateTempFileContents(tempFile2);
            dirService.DirList(gingerAct, tempFolder);

            //Assert
            Assert.AreEqual("2", gingerAct.Output["FileCount"], "FileCount=2");
        }

        private static void EmptyTempFolder()
        {
            string tempFolder = Path.Combine(TestResources.GetTempFile(""), testFolderName);
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
