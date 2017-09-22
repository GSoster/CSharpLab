using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataToProtect = "This is a bunch of super secret content!";
            var dataToProtectArray = Encoding.Unicode.GetBytes(dataToProtect);

            /* Simple file encryption
             *  - Encrypts and Decrypts Files
             *  - Fast to encrypt/decrypt
             *  - Based on our credentials
             */
            #region File.Encrypt

            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyDataFile.txt");

            //encrypt a file in the file system
            File.WriteAllText(fileName, dataToProtect);

            //now we can encrypt it - only we can acess it now
            File.Encrypt(fileName);

            #endregion
        }
    }
}
