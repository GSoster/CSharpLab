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
        
        public static List<FileInfo> GetAllFilesFromPathByExtension(string path, string extension = "jpg")
        {
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (extension[0] != '*')
                extension = "*." + extension;

            foreach (var p in dirInfo.GetFiles(extension))
            {
                files.Add(p);
            }
            return files;
        }

    }
}
