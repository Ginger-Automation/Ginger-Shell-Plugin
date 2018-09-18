using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GingerShellPluginTest
{
    [TestClass]
    public class FileServiceUnitTest
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
        public void TestGingerFileService_CheckFileExists()
        {
            //Arrange
            string tempFileName = TestResources.GetTempFile("FileServiceFileExists.txt");
            FileService service = new FileService();
            GingerAction gingerAct = new GingerAction();

            //Act
            CreateTempFileContents(tempFileName);
            service.FileExists(gingerAct, tempFileName);

            //Assert
            Assert.AreEqual(gingerAct.Errors, 0);
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
