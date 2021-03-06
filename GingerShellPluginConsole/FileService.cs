﻿using Amdocs.Ginger.Plugin.Core;

namespace GingerShellPlugin
{
    [GingerService("FILESER", "File Service Server")]
    public class FileService : IGingerService, IStandAloneAction
    {

        [GingerAction("FileExists", "Run File Exists Command")]
        public void FileExists(IGingerAction GA, string fileName)
        {
            GA.AddOutput("FileName", fileName);
            if (System.IO.File.Exists(fileName))
            {
                GA.AddOutput("FileExists", "True");
            }
            else
            {
                GA.AddOutput("FileExists", "False");
            }
        }


        [GingerAction("FileDelete", "Run File Delete Command")]
        public void FileDelete(IGingerAction GA, string fileName)
        {
            GA.AddOutput("FileName", fileName);
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
                GA.AddOutput("FileDelete", "True");
            }
            else
            {
                GA.AddOutput("FileDelete", "False");
            }
        }


        [GingerAction("FileCopy", "Run File Copy Command")]
        public void FileCopy(IGingerAction GA, string sourceFileName, string destFileName)
        {
            GA.AddOutput("SourceFileName", sourceFileName);
            GA.AddOutput("TargetFileName", destFileName);
            if (System.IO.File.Exists(sourceFileName))
            {
                System.IO.File.Copy(sourceFileName, destFileName);
                GA.AddOutput("FileCopy", "True");
            }
            else
            {
                GA.AddOutput("FileCopy", "False");
            }
        }


        [GingerAction("FileMove", "Run File Move Command")]
        public void FileMove(IGingerAction GA, string sourceFileName, string destFileName)
        {
            GA.AddOutput("SourceFileName", sourceFileName);
            GA.AddOutput("TargetFileName", destFileName);
            if (System.IO.File.Exists(sourceFileName))
            {
                System.IO.File.Move(sourceFileName, destFileName);
                GA.AddOutput("FileMove", "True");
            }
            else
            {
                GA.AddOutput("FileMove", "False");
            }
        }


        [GingerAction("FileInfo", "Run File Info Command")]
        public void FileInfo(IGingerAction GA, string fileName)
        {
            GA.AddOutput("FileName", fileName);
            if (System.IO.File.Exists(fileName))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                GA.AddOutput("FileInfo", "True");
                GA.AddOutput("FileInfo_LastAccessTime", fi.LastAccessTime);
                GA.AddOutput("FileInfo_Length", fi.Length);
                GA.AddOutput("FileInfo_CreationTime", fi.CreationTime);
            }
            else
            {
                GA.AddOutput("FileInfo", "False");
            }
        }


    }
}
