using System.Security.Cryptography;
using System.Text;

namespace Honti.CryptoEngine
{
    public class MD5Hash
    {
        public static string Encrypt(string plainText)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(plainText);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X1"));
            }
            return sb.ToString();
        }

    }
}
