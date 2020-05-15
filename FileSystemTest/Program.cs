using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory();
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
                var destDirName = GetFolderByName(FolderNames.SaveData)+"SavaData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.Move(savedDataDir, destDirName);
            }

        }
        public string GetFolderByName(FolderNames name)
        {
            return folders[(int)name];
        }
    }
}
