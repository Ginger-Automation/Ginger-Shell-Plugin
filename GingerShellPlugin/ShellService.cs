using Amdocs.Ginger.Plugin.Core;
using System;
using System.Diagnostics;

namespace GingerShellPlugin
{

    [GingerService("SHELL", "Shell Server")]
    public class ShellService : IGingerService, IStandAloneAction
    {

        [GingerAction("RunShell", "Run OS Shell Command")]
        public void RunShell(IGingerAction GA, string commandStr)
        {
            string output;

            string curOS = OperatingSystem.GetCurrentOS();

            switch(curOS)
            {
                case "mac":
                    break;
                case "win":
                    break;
                case "unx":
                    break;
                default:
                    break;
            }

            if (OperatingSystem.IsMacOS())
            {
                //mac code 
                Console.WriteLine("Mac Operating System!");
            }
            else if (OperatingSystem.IsLinux() )
            {
                //linux code
                Console.WriteLine("Linux Operating System!");
            }
            else if (OperatingSystem.IsWindows())
            {
                //windows code
                Console.WriteLine("Windows Operating System!");
                output = Execute(@"C:\Windows\System32\cmd.exe", "ipconfig");
            }

            //Console.WriteLine("Starting PACT server at port: " + port);
            //check input params and add errors if invalid
            //if (port == 0)
            //    {
            //        GA.AddError("Port cannot be 0");
            //        return;
            //    }

            //SV = new ServiceVirtualization(port);
            //GA.AddOutput("port", port);
            //GA.AddOutput("url", SV.MockProviderServiceBaseUri);

            //ExInfo
            //GA.AddExInfo("PACT Mock Server Started on port: " + port + " " + SV.MockProviderServiceBaseUri);
            //Console.WriteLine("PACT Server started");

            // code to run on the shell
            string retOutput = Execute(@"C:\Windows\System32\cmd.exe", @"/c dir \windows", true, true, false);
        }       


        public static string Execute(string executable,
               string arguments,
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
                process.StartInfo = new ProcessStartInfo(executable, arguments);

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
                    executable, arguments, Environment.NewLine, standardErrorString));

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
                    string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.", executable, arguments), e);
            }

            // Return the output string
            return standardOutputString;
        }




    }



}
