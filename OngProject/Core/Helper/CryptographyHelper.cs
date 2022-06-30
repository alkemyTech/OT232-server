using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class CryptographyHelper
    {
        //Encripta Contraseña
        public string CreateHashPass(string password)
        {
            using (var hmac = SHA256.Create())
            {
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                var sb = new StringBuilder();
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    sb.Append(passwordHash[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
