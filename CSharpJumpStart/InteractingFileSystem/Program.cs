using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractingFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = System.IO.Directory.GetCurrentDirectory();
            var file = System.IO.Path.Combine(dir, "File.txt");
            var content = "how now brown cow?";

            //write
            System.IO.File.WriteAllText(file, content);


            //read
            var read = System.IO.File.ReadAllText(file);
            Trace.Assert(read.Equals(content));

        }
    }
}
