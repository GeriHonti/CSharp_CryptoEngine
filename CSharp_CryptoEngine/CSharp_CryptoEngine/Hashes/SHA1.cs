using System.Security.Cryptography;
using System.Text;

namespace Honti.CryptoEngine
{
    public class SHA1Hash
    {
        public static string Encrypt(string plaintext)
        {
            var sha1Provider = new SHA1CryptoServiceProvider();
            var hasedvalue = sha1Provider.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
            var str = new StringBuilder();
            foreach (var t in hasedvalue)
            {
                str.Append(t.ToString("X1"));
            }
            return str.ToString();
        }
      
    }
}
