﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory();
            app.CreateFile();
            app.CopySavedData();
            app.DetletTemp();


            Console.Read();

        }

        public string[] folders =
        {
            @"workspace\" ,
            @"workspace\Archive\",
            @"workspace\temp",
            @"workspace\temp\savedfiles"

        };

        public enum FolderNames
        {
            workspace,
            Archive,
            temp,
            SaveData
        }
        

        public void CreateDirectory ()
        {
            var total = folders.Length;
            for (var i = 0; i < total; i++)
            {
                var dirName = GetFolderByName((FolderNames)i);
                if (Directory.Exists(dirName))
                {
                    Console.WriteLine("directory " + folders[i] + " exsit");
                }
                else
                {
                    Directory.CreateDirectory(dirName);
                    Console.WriteLine("dir " + folders[i] + " is created");
                }
            }
        }

        public void DetletTemp()
        {
            var tmpDir = GetFolderByName(FolderNames.temp);
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir,true);
            }
        }

        public void CopySavedData()
        {
            var savedDataDir = GetFolderByName(FolderNames.SaveData);
            if (Directory.Exists(savedDataDir))
            {
                var destDirName = GetFolderByName(FolderNames.Archive)+"SavaData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.Move(savedDataDir, destDirName);
            }

        }
        public string GetFolderByName(FolderNames name)
        {
            return folders[(int)name];
        }

        public void CreateFile ()
        {
            var path = GetFolderByName(FolderNames.SaveData)+@"/TestFile.txt";
            File.WriteAllText(path, "hello world!");

            var fileInfo = new FileInfo(path);
            var name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var ext = fileInfo.Extension;
            var size = fileInfo.Length;

            Console.WriteLine("Created file " + name + "with extension "+ ext+" with a size of " +size);
        }
    }
}
