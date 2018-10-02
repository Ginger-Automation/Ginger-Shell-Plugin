using Amdocs.Ginger.Plugin.Core;

namespace GingerShellPlugin
{
    [GingerService("DIRSERV", "Dir Service Server")]
    public class DirService : IGingerService, IStandAloneAction
    {

        [GingerAction("DirExists", "Check Dir Exists")]
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


        [GingerAction("DirInfo", "Run Dir Info Command")]
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


            System.IO.Directory.Delete(dirName);
        }


        [GingerAction("DirDelete", "Delete Directory")]
        public void DirDelete(IGingerAction GA, string dirName)
        {
            GA.AddOutput("DirName", dirName);
            if (System.IO.Directory.Exists(dirName))
            {
                System.IO.Directory.Delete(dirName);
                GA.AddOutput("DirDelete", "True");
            }
            else
            {
                GA.AddOutput("DirDelete", "False");
            }
        }

        [GingerAction("DirList", "List Directory")]
        public void DirList(IGingerAction GA, string dirName)
        {
            GA.AddOutput("DirName", dirName);
            if (System.IO.Directory.Exists(dirName))
            {
                string[] filesList = System.IO.Directory.GetFiles(dirName);
                int fileNum = 0;
                foreach (string curFile in filesList)
                {
                    GA.AddOutput("File-" + (++fileNum), curFile);
                }
                GA.AddOutput("FileCount", fileNum.ToString());
                GA.AddOutput("DirList", "True");
            }
            else
            {
                GA.AddOutput("DirList", "False");
            }
        }

    }
}
