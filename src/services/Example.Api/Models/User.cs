using Core.Business.Models;
using System.Security.Cryptography;
using System.Text;

namespace Example.Api.Models
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public static string HashPassword(string password)
        {
            var algorithm = SHA256.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(bytes).Replace("-", string.Empty);
            return hash;
        }

    }
}
