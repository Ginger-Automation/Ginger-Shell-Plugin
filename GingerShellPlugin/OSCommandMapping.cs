using System;
using System.Collections.Generic;
using System.Text;

namespace GingerShellPlugin
{
    public class OSCommandMapping
    {
        public enum CommandList
        {
            IPCONFIG = 1,
            NETSTAT = 2
        }

        public string CommandName { get; set; }

        public string CommandParams { get; set; }

        public string LinuxSyntax { get; set; }

        public string WindowsSyntax { get; set; }

        public string MacSyntax { get; set; }

        public void CreateCommand(string commandName, string linuxSyntax, string windowsSyntax, string macSyntax)
        {
            this.CommandName = commandName;
            this.LinuxSyntax = linuxSyntax;
            this.WindowsSyntax = windowsSyntax;
            this.MacSyntax = macSyntax;
        }

        public string GetOSMappingCommand()
        {
            if (OperatingSystem.IsLinux())
            {
                return LinuxSyntax;
            } else if (OperatingSystem.IsWindows())
            {
                return WindowsSyntax;
            } else if (OperatingSystem.IsMacOS())
            {
                return MacSyntax;
            }
            return string.Empty;
        }

    }

}
