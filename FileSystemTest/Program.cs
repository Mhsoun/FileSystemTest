using System;
using System.IO;


namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory();
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

        

        public void CreateDirectory ()
        {
            var total = folders.Length;
            for (var i = 0; i < total; i++)
            {
                var dirName = folders[i];
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
            var tmpDir = folders[2];
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir,true);
            }
        }
    }
}
