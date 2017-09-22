using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

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

            /*
             * Windows Data Protection
             * It uses the capabilities of the Windows operating system
             * - Encrypts and decrypts byte[]
             *  - Fast to encrypt/decrypt
             *  - Based on our credentials
             */
            #region Windows Data Protection

            //null can be replaced with a byte[] for aditional entropy
            //DataProtectionScope.CurrentUser could also be DataProtectionScope.CurrentMachine
            var wdpEncryptedData = ProtectedData.Protect(dataToProtectArray, null, DataProtectionScope.CurrentUser);

            var wdpnUnEncryptedData = ProtectedData.Unprotect(wdpEncryptedData, null, DataProtectionScope.CurrentUser);
            var wdpnUnEncryptedString = Encoding.Unicode.GetString(wdpnUnEncryptedData);


            #endregion

        }
    }
}
