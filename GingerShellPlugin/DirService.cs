using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GingerShellPlugin
{
    [GingerService("DIRSERV", "Dir Service Server")]
    public class DirService : IGingerService, IStandAloneAction
    {

        public DirService()
        {
            //
        }

        [GingerAction("DirExists", "Run OS Shell Command")]
        public void DirExists(IGingerAction GA, string dirName)
        {
            GA.AddOutput("DirName", dirName);
            if (System.IO.Directory.Exists(dirName))
            {
                GA.AddOutput("DirExists", "True");
            }
            else
            {
                GA.AddOutput("DirExists", "False");
            }
        }


        [GingerAction("DirInfo", "Run OS Shell Command")]
        public void DirInfo(IGingerAction GA, string dirName)
        {
            GA.AddOutput("DirName", dirName);
            if (System.IO.Directory.Exists(dirName))
            {
                GA.AddOutput("DirInfo", "True");

                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(dirName);
                GA.AddOutput("DirInfo_Parent", directoryInfo.Parent);
                GA.AddOutput("DirInfo_Root", directoryInfo.Root);
                GA.AddOutput("DirInfo_Name", directoryInfo.Name);
                GA.AddOutput("DirInfo_FullName", directoryInfo.FullName);
                GA.AddOutput("DirInfo_CreationTime", directoryInfo.CreationTime);
                
            }
            else
            {
                GA.AddOutput("DirInfo", "False");
            }
        }

    }
}
