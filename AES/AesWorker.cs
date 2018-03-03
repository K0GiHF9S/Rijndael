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
            byte[] encryptedSource;
            try
            {
                using (var rijndael = new RijndaelManaged())
                {
                    InitializeRijndael(password, rijndael);
                    var encryptor = rijndael.CreateEncryptor();
                    var bSource = Encoding.UTF8.GetBytes(source);
                    encryptedSource = encryptor.TransformFinalBlock(bSource, 0, bSource.Length);
                }
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
            return Convert.ToBase64String(encryptedSource);
        }

        public static string Decrypt(string source, string password)
        {
            byte[] decryptedSource;
            try
            {
                using (var rijndael = new RijndaelManaged())
                {
                    InitializeRijndael(password, rijndael);
                    var decryptor = rijndael.CreateDecryptor();
                    var bSource = Convert.FromBase64String(source);
                    decryptedSource = decryptor.TransformFinalBlock(bSource, 0, bSource.Length);
                }
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
            return Encoding.UTF8.GetString(decryptedSource);
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
