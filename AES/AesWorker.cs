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
            try
            {
                using (var rijndael = new RijndaelManaged())
                {
                    InitializeRijndael(password, rijndael);
                    using (var mStream = new MemoryStream())
                    using (var encryptor = rijndael.CreateEncryptor())
                    using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cStream))
                        {
                            writer.Write(source);
                        }
                        encryptedSource = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return null;
            }
            return encryptedSource;
        }

        public static string Decrypt(string source, string password)
        {
            string decryptedSource;
            try
            {
                using (var rijndael = new RijndaelManaged())
                {
                    InitializeRijndael(password, rijndael);
                    using (var mStream = new MemoryStream(Convert.FromBase64String(source)))
                    using (var decryptor = rijndael.CreateDecryptor())
                    using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cStream))
                    {
                        decryptedSource = reader.ReadToEnd();
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
