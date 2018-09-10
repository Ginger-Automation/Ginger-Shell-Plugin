using Amdocs.Ginger.Plugin.Core;
using GingerShellPlugin;
using System;

namespace GingerShellPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ShellService service = new ShellService();
            GingerAction GA = new GingerAction();
            service.RunShell(GA, "1234");
        }
    }
}
