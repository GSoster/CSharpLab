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

            /*
             * Symmetric Encryption
             * - One key is used for both encryption and decryption
             * - Faster than Asymmetric encryption
             * - Cryptography namespace includes five symmetric algorithms:
             *   - Aes (recommended)
             *   - DES
             *   - RC2
             *   - Rijndael (basically the same as Aes but allows weaker keys)
             *   - TripleDES
             */
            #region Symmetric Encryption
            // Uses Rijndael as an algorithm
            // two classes Rijndael and Aes - use Aes (more secure)

            // array of 16 random bytes - must be used for decryption - 
            // should be secret
            var key = new byte[] { 12, 2, 56, 117, 12, 67, 33, 23, 12, 2, 56, 117, 12, 67, 33, 23 };

            // another list of 16 bytes - can be shared publically,
            // should be changed for each message exchange
            var initializationVector = new byte[] { 37, 99, 102, 23, 12, 22, 156, 204, 11, 12, 23, 44, 55, 1, 157, 233 };

            byte[] symEncryptedData;

            //save for reuse
            var algorithm = Aes.Create();

            // Encrypt
            using (var encryptor = algorithm.CreateEncryptor(key, initializationVector))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                //pass the data that we want to protect to the memory (memoryStream)
                cryptoStream.Write(dataToProtectArray, 0, dataToProtectArray.Length);
                cryptoStream.FlushFinalBlock();
                symEncryptedData = memoryStream.ToArray();


            }

            // Decrypt
            byte[] symUnEncryptedData;
            using (var decryptor = algorithm.CreateDecryptor(key, initializationVector))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(symEncryptedData, 0, symEncryptedData.Length);
                cryptoStream.FlushFinalBlock();
                symUnEncryptedData = memoryStream.ToArray();
            }

            algorithm.Dispose();

            if (dataToProtectArray.SequenceEqual(symUnEncryptedData))
            {
                Console.WriteLine("Symmetric encrypted values match!");
            }

            #endregion

            /*
             * Asymmetric (or Public Key) Encryption
             * - one key is used for encryption and another key for decryption
             * - commonly used for digital signatures
             * - Cryptography namespace include four asymmetric algorithms:
             *   - DSA
             *   - ECDiffieHellman
             *   - EDCsa
             *   - RSA (most popular)
             */
            #region Asymmetric Encryption
            byte[] signature;
            byte[] publicAndPrivateKey;
            byte[] publicKeyOnly;
            var hashImplementation = SHA1.Create();

            // create a signature, create our public and private keys - we could save these out as XML, etc.
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                signature = rsaProvider.SignData(dataToProtectArray, hashImplementation);
                publicAndPrivateKey = rsaProvider.ExportCspBlob(true);
                publicKeyOnly = rsaProvider.ExportCspBlob(false);
            }

            // create a new RSA
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                // import our public key
                rsaProvider.ImportCspBlob(publicKeyOnly);

                // has it been tampered with?
                if (!rsaProvider.VerifyData(dataToProtectArray, hashImplementation, signature))
                {
                    Console.WriteLine("Data has been tampered with");
                }

                // now let's tamper with our data

                dataToProtectArray[5] = 255;
                if (!rsaProvider.VerifyData(dataToProtectArray, hashImplementation, signature))
                {
                    Console.WriteLine("Data has been tampered with");
                }
            }

            hashImplementation.Dispose();
            #endregion
        }
    }
}
