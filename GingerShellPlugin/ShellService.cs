using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GingerShellPlugin
{

    [GingerService("SHELL", "Shell Server")]
    public class ShellService : IGingerService, IStandAloneAction
    {
        List<OSCommandMapping> osCommandMapList = new List<OSCommandMapping>();

        public ShellService()
        {
            PopulateOSCommandMapping();
        }

        [GingerAction("RunShell", "Run OS Shell Command")]
        public void RunShell(IGingerAction GA, string commandStr)
        {
            this.RunShell(GA, commandStr, string.Empty);
        }

        [GingerAction("RunShell", "Run OS Shell Command")]
        public void RunShell(IGingerAction GA, string commandStr, string commandParams)
        {
            string retOutput = string.Empty;
            string currOS = string.Empty;

            string osCommandStr = GetRelativeOSCommand(commandStr);

            GA.AddOutput("command", osCommandStr);
            GA.AddOutput("params", commandParams);

            if (OperatingSystem.IsMacOS())
            {
                //mac code 
                Console.WriteLine("Mac Operating System!");
                currOS = "mac";
            }
            else if (OperatingSystem.IsLinux())
            {
                //linux code
                Console.WriteLine("Linux Operating System!");
                currOS = "linux";
                retOutput = ExecuteShellCommand(osCommandStr, commandParams, true, true, false);

            }
            else if (OperatingSystem.IsWindows())
            {
                //windows code
                Console.WriteLine("Windows Operating System!");
                currOS = "windows";
                retOutput = ExecuteShellCommandWindows(osCommandStr, commandParams, true, true, false);
            } else
            {
                GA.AddError("OS not supported");
                return;
            }

            GA.AddExInfo(retOutput);
            GA.AddOutput("curr_os", currOS);

            Console.WriteLine("Output from the execution...");
            Console.Write(retOutput);

        }

        private void PopulateOSCommandMapping()
        {
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "IPCONFIG", LinuxSyntax = "ifconfig", MacSyntax = "ifconfig", WindowsSyntax = "ipconfig" });
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "NETSTAT", LinuxSyntax = "nestat", MacSyntax = "netstat", WindowsSyntax = "netstat" });
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "FILES_LIST", LinuxSyntax = "ls", MacSyntax = "ls", WindowsSyntax = "dir" });
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "COPY_FILE", LinuxSyntax = "cp", MacSyntax = "cp", WindowsSyntax = "copy" });
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "RENAME_FILE", LinuxSyntax = "mv", MacSyntax = "mv", WindowsSyntax = "rename" });
            osCommandMapList.Add(new OSCommandMapping() { CommandName = "CLEAR_SCREEN", LinuxSyntax = "clear", MacSyntax = "clear", WindowsSyntax = "cls" });
        }

        private string GetRelativeOSCommand(string commandName)
        {
            string commandSyntax = string.Empty;
            OSCommandMapping oSCommandMapping = osCommandMapList.Find(x => x.CommandName.Equals(commandName));
            commandSyntax = oSCommandMapping.GetOSMappingCommand();
            return commandSyntax;
        }

        public static string ExecuteShellCommand(string commandExecutable,
               string commandArguments,
               bool standardOutput = false,
               bool standardError = false,
               bool throwOnError = false)
        {
            // This will be out return string
            string standardOutputString = string.Empty;
            string standardErrorString = string.Empty;

            // Use process
            Process process;

            try
            {
                // Setup our process with the executable and it's arguments
                process = new Process();

                if (string.IsNullOrEmpty(commandArguments))
                {
                    process.StartInfo = new ProcessStartInfo(commandExecutable);
                } else
                {
                    process.StartInfo = new ProcessStartInfo(commandExecutable, commandArguments);
                }


                // To get IO streams set use shell to false
                process.StartInfo.UseShellExecute = false;

                // If we want to return the output then redirect standard output
                if (standardOutput) process.StartInfo.RedirectStandardOutput = true;

                // If we std error or to throw on error then redirect error
                if (standardError || throwOnError) process.StartInfo.RedirectStandardError = true;

                // Run the process
                process.Start();

                // Get the standard error
                if (standardError || throwOnError) standardErrorString = process.StandardError.ReadToEnd();

                // If we want to throw on error and there is an error
                if (throwOnError && !string.IsNullOrEmpty(standardErrorString))
                throw new Exception(
                    string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.",
                    commandExecutable, commandArguments, Environment.NewLine, standardErrorString));

                // If we want to return the output then get it
                if (standardOutput) standardOutputString = process.StandardOutput.ReadToEnd();

                // If we want standard error then append it to our output string
                if (standardError) standardOutputString += standardErrorString;

                // Wait for the process to finish
                process.WaitForExit();
            }
            catch (Exception e)
            {
                // Encapsulate and throw
                throw new Exception(
                    string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.", commandExecutable, commandArguments), e);
            }

            // Return the output string
            return standardOutputString;
        }

        public static string ExecuteShellCommandWindows(string commandStr,
               string commandArguments,
               bool standardInput = false,
               bool standardOutput = false,
               bool standardError = false)
        {
            // This will be out return string
            string standardOutputString = string.Empty;
            string standardErrorString = string.Empty;

            // Use process
            Process process;

            try
            {
                // Setup our process with the executable and it's arguments
                process = new Process();

                process.StartInfo.FileName= "cmd.exe";

                // To get IO streams set use shell to false
                process.StartInfo.UseShellExecute = false;

                // To set the standard input
                if (standardInput) process.StartInfo.RedirectStandardInput = true;

                // If we want to return the output then redirect standard output
                if (standardOutput) process.StartInfo.RedirectStandardOutput = true;

                // No Window
                process.StartInfo.CreateNoWindow = true;

                // If we std error or to throw on error then redirect error
                if (standardError) process.StartInfo.RedirectStandardError = true;

                // Run the process
                process.Start();

                string commandLineStr = string.Empty;
                if (string.IsNullOrEmpty(commandArguments))
                {
                    commandLineStr = commandStr;
                }
                else
                {
                    commandLineStr = commandStr + " " + commandArguments;
                }

                process.StandardInput.WriteLine(commandLineStr);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                // If we want to return the output then get it
                if (standardOutput) standardOutputString = process.StandardOutput.ReadToEnd();

                // If we want standard error then append it to our output string
                if (standardError) standardOutputString += process.StandardError.ReadToEnd();

                // Wait for the process to finish
                process.WaitForExit();
            }
            catch (Exception e)
            {
                // Encapsulate and throw
                throw new Exception(
                    string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.", commandStr, commandArguments), e);
            }

            // Return the output string
            return standardOutputString;
        }



        //public static string Execute_Win(string commandStr)
        //{
        //    Process cmd = new Process();
        //    cmd.StartInfo.FileName = "cmd.exe";
        //    cmd.StartInfo.RedirectStandardInput = true;
        //    cmd.StartInfo.RedirectStandardOutput = true;
        //    cmd.StartInfo.CreateNoWindow = true;
        //    cmd.StartInfo.UseShellExecute = false;
        //    cmd.Start();

        //    cmd.StandardInput.WriteLine(commandStr);
        //    cmd.StandardInput.Flush();
        //    cmd.StandardInput.Close();
        //    cmd.WaitForExit();
        //    return cmd.StandardOutput.ReadToEnd();
        //}



    }



}
