using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Honti.CryptoEngine
{
    class SHA384Hash
    {
        public static string Encrypt(string plainText)
        {
            var sha384 = SHA384.Create();
            var hash = sha384.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            var str = new StringBuilder();

            foreach (var t in hash)
            {
                str.Append(t.ToString("X1"));
            }
            return str.ToString();
        }
    }
}
