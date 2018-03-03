using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rijndael
{
    static class RijndaelWorker
    {
        private static readonly string SALT = @"akfv#oVfktRhrjo!hjm5t";

        public static string Encrypt(string source, string password)
        {
            string encryptedSource;
            using (var rijndael = new RijndaelManaged())
            {
                InitializeRijndael(password, rijndael);
                using (var encryptor = rijndael.CreateEncryptor())
                {
                    var bSorce = Encoding.UTF8.GetBytes(source);
                    encryptedSource = Convert.ToBase64String(encryptor.TransformFinalBlock(bSorce, 0, bSorce.Length));
                }
            }
            return encryptedSource;
        }

        public static string Decrypt(string source, string password)
        {
            string decryptedSource;
            using (var rijndael = new RijndaelManaged())
            {
                InitializeRijndael(password, rijndael);
                using (var decryptor = rijndael.CreateDecryptor())
                {
                    try
                    {
                        var bSorce = Convert.FromBase64String(source);
                        decryptedSource = Encoding.UTF8.GetString(decryptor.TransformFinalBlock(bSorce, 0, bSorce.Length));
                    }
                    catch (FormatException e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.Message);
                        decryptedSource = null;
                    }
                    catch (CryptographicException e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.Message);
                        decryptedSource = null;
                    }
                }
            }
            return decryptedSource;
        }

        private static void InitializeRijndael(string password, RijndaelManaged rijndael)
        {
            rijndael.KeySize = 128;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;

            var bSalt = Encoding.UTF8.GetBytes(SALT);
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, bSalt);
            deriveBytes.IterationCount = 1000;

            rijndael.Key = deriveBytes.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = deriveBytes.GetBytes(rijndael.BlockSize / 8);
        }
    }
}
