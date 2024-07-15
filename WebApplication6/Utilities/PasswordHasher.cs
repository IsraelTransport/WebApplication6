using System.Security.Cryptography;

namespace WebApplication6.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var salt = hmac.Key;
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                // Combine salt and hash
                var hashBytes = new byte[salt.Length + hash.Length];
                Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
                Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);
            var salt = new byte[128]; // Assuming HMACSHA512 produces a 128-byte key
            Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hashBytes[i + salt.Length])
                        return false;
                }
            }

            return true;
        }
    }
}
