using Amdocs.Ginger.CoreNET.Drivers.CommunicationProtocol;
using Amdocs.Ginger.Plugin.Core;
using GingerCoreNET.DriversLib;
using GingerShellPlugin;
using System;

namespace GingerShellPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Shell Plugin");

            GingerNode gingerNode = new GingerNode(new ShellService());
            gingerNode.StartGingerNode("SHELL 1", SocketHelper.GetLocalHostIP(), 15001);

            Console.ReadKey();

            //ShellService shellService = new ShellService();
            //FileService fileService = new FileService();
            //GingerAction GA = new GingerAction();

            //shellService.RunShell(GA, "IPCONFIG");

            //fileService.FileInfo(GA, "/home/ginger/dotnet/ThirdPartyNotices.txt");

            // C:\Users\raviket>dotnet C:\Users\raviket\Source\Repos\GingerShellPlugin\GingerShellPluginConsole\bin\Debug\netcoreapp2.1\GingerShellPluginConsole.dll
        }

    }
}

// dotnet instllation
//https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.401-linux-x64-binaries

// very important documentation: 
//https://github.com/dotnet/core/blob/214Rel/Documentation/build-and-install-rhel6-prerequisites.md
