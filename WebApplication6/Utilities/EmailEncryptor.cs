using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication6.Utilities
{
    public static class Encryptor
    {
        // Ensure your key is exactly 32 bytes (256 bits) for AES-256
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        // Ensure your IV is exactly 16 bytes (128 bits)
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

        public static string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(cipherBytes))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
