using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using System;

namespace GingerShellPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Shell Plugin");
            ShellService service = new ShellService();
            GingerAction GA = new GingerAction();
            service.RunShell(GA, "dir");

            // C:\Users\raviket>dotnet C:\Users\raviket\Source\Repos\GingerShellPlugin\GingerShellPluginConsole\bin\Debug\netcoreapp2.1\GingerShellPluginConsole.dll
        }
    }
}
