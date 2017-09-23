using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractingFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // application folder
            var dir = System.IO.Directory.GetCurrentDirectory();

            var file = System.IO.Path.Combine(dir, "File.txt");
            var content = "how now brown cow?";

            //write
            System.IO.File.WriteAllText(file, content);


            //read
            var read = System.IO.File.ReadAllText(file);
            Trace.Assert(read.Equals(content));

            //special folders
            var doc = Environment.SpecialFolder.MyDocuments;
            var app = Environment.SpecialFolder.CommonApplicationData;
            var prog = Environment.SpecialFolder.ProgramFiles;
            var desk = Environment.SpecialFolder.Desktop;

            // isolated storage folder(s)
            var iso = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly, "Demo").GetDirectoryNames("*");

            //manual path
            var temp = new System.IO.DirectoryInfo("C:\temp");

            #region Interacting with Files
            //files
            foreach (var item in System.IO.Directory.GetFiles(dir))
                Console.WriteLine(System.IO.Path.GetFileName(item));

            // rename / move
            var path1 = "C:\temp\file1.txt";
            var path2 = "C:\temp\file2.txt";
            System.IO.File.Move(path1, path2);

            // file info
            var info = new System.IO.FileInfo(path1);
            Console.WriteLine("{0}kb", info.Length / 1000);

            #endregion


        }
    }
}
