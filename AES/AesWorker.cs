using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rijndael
{
    static class RijndaelWorker
    {
        private static readonly int KEY_SIZE = 128;
        private static readonly int BLOCK_SIZE = 128;
        private static readonly string SALT = @"akfv#oVfktRhrjo!hjm5t";

        public static string Encrypt(string source, string password)
        {
            string encryptedSource;
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.KeySize = KEY_SIZE;
                rijndael.BlockSize = BLOCK_SIZE;
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Key = GenerateKey(password);
                rijndael.GenerateIV();

                byte[] bEncryptedSource;
                using (var encryptor = rijndael.CreateEncryptor())
                {
                    var bSource = Encoding.UTF8.GetBytes(source);
                    bEncryptedSource = encryptor.TransformFinalBlock(bSource, 0, bSource.Length); ;
                }

                byte[] ivAndBSource = new byte[rijndael.IV.Length + bEncryptedSource.Length];
                Array.Copy(rijndael.IV, ivAndBSource, rijndael.IV.Length);
                Array.Copy(bEncryptedSource, 0, ivAndBSource, rijndael.IV.Length, bEncryptedSource.Length);
                encryptedSource = Convert.ToBase64String(ivAndBSource);
            }
            return encryptedSource;
        }

        public static string Decrypt(string source, string password)
        {
            string decryptedSource;
            try
            {
                var ivAndBSource = Convert.FromBase64String(source);
                if (ivAndBSource.Length < BLOCK_SIZE / 8)
                {
                    return null;
                }

                using (var rijndael = new RijndaelManaged())
                {
                    rijndael.KeySize = KEY_SIZE;
                    rijndael.BlockSize = BLOCK_SIZE;
                    rijndael.Mode = CipherMode.CBC;
                    rijndael.Padding = PaddingMode.PKCS7;
                    rijndael.Key = GenerateKey(password);

                    var iv = new byte[BLOCK_SIZE / 8];
                    Array.Copy(ivAndBSource, 0, iv, 0, iv.Length);
                    var bSource = new byte[ivAndBSource.Length - iv.Length];
                    Array.Copy(ivAndBSource, iv.Length, bSource, 0, bSource.Length);
                    rijndael.IV = iv;
                    
                    using (var decryptor = rijndael.CreateDecryptor())
                    {
                        decryptedSource = Encoding.UTF8.GetString(decryptor.TransformFinalBlock(bSource, 0, bSource.Length));
                    }
                }
            }
            catch (FormatException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
            return decryptedSource;
        }

        private static byte[] GenerateKey(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(SALT);
            var deriveBytes = new Rfc2898DeriveBytes(password, salt);
            deriveBytes.IterationCount = 1000;
            return deriveBytes.GetBytes(KEY_SIZE / 8);
        }
    }
}
