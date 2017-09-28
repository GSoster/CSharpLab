using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PhotoGallery.Util
{
    static class FileHandler
    {

        //Todo: If first two char from extension is not *. it should be added to the extension received.
        public static List<FileInfo> GetAllFilesFromPath(string path, string extension = "jpg")
        {
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (var p in dirInfo.GetFiles(extension))
            {
                files.Add(p);
            }
            return files;
        }

    }
}
