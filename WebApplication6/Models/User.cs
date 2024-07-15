using System.ComponentModel.DataAnnotations;
using WebApplication6.Utilities;

namespace WebApplication6.Models
{
    public class User
    {
        public int UserID { get; set; }

        private string userName;
        public string UserName
        {
            get => Encryptor.Decrypt(userName);
            set => userName = Encryptor.Encrypt(value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => password = PasswordHasher.HashPassword(value);
        }

        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
    }
}
