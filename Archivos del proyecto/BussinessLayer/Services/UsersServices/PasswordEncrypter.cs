using System;
using System.Security.Cryptography;
using System.Text;

namespace ServicesLayer.Bussiness
{
    public class PasswordEncrypter
    {
        public static string Compute256Hash(string password)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string   
            StringBuilder hashBytes = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                hashBytes.Append(hash[i].ToString("x2"));
            }
            return hashBytes.ToString();
        }
    }
}
