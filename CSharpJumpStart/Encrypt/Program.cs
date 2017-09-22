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


            /*
             * Hashing
             * - One-way encryption
             * - Fast 
             * - Used for storing passwords, comparing files, data corruption/tamper checking
             */
            #region Hashing
            //this represents a hashed passwod stored in a database
            var storedPasswordHash = new byte[]
                {
                    148, 152, 235, 251, 242, 51, 18, 100, 176, 51, 147,
                    249, 128, 175, 164, 106, 204, 48, 47, 154, 75, 82,
                    83, 170, 111, 8, 107, 51, 13, 83, 2, 252
                };

            var password = Encoding.Unicode.GetBytes("P4ssw0rd!");
            var passwordHash = SHA256.Create().ComputeHash(password);

            // nice convenient method - can also supply a custom comparator
            if (passwordHash.SequenceEqual(storedPasswordHash))
            {
                Console.WriteLine("Passwords Match!");
            }



            #endregion

        }
    }
}
