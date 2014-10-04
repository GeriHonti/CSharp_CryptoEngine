using System.Security.Cryptography;
using System.Text;

namespace Honti.CryptoEngine
{
    class SHA256Hash
    {
        public static string Encrypt(string plainText)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            var str = new StringBuilder();
            foreach (var t in hash)
            {
                str.Append(t.ToString("X1"));
            }
            return str.ToString();
        }

       

    }
}
