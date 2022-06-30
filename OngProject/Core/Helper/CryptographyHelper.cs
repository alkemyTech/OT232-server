using System.Security.Cryptography;
using System.Text;

namespace OngProject.Core.Helper
{
    public class CryptographyHelper
    {
        public static string CreateHashPass(string password) 
        {
            var sb = new StringBuilder();
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length ; i++)
                {
                    sb.Append(passwordHash);
                }
                return sb.ToString();
            }
        }
    }
}
