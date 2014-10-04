using System.Security.Cryptography;
using System.Text;

namespace Honti.CryptoEngine
{
    public class SHA512Hash
    {
        public static string Encrypt(string input)
        {
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            var str = new StringBuilder();
            foreach (var t in hash)
            {
                str.Append(t.ToString("X1"));
            }
            return str.ToString();
        }
    }
}
