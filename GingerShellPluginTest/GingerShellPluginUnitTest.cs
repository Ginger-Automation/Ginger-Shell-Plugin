using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GingerShellPluginTest
{
    [TestClass]
    public class GingerShellPluginUnitTest
    {
        [TestMethod]
        public void TestGingerShell_RunShell()
        {
            //Arrange
            ShellService service = new ShellService();
            GingerAction GA = new GingerAction();

            //Act
            service.RunShell(GA, "dir");

            //Assert
            Assert.AreEqual(null, GA.Errors, "No Errors");
        }


    }
}
