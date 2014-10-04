using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Honti.CryptoEngine
{
    public class Hash
    {
        public static string Encrypt(string plainText, HashingMethod method = HashingMethod.SHA1)
        {
            string hashed;
            switch (method)
            {
                case HashingMethod.MD5:
                    hashed = MD5Hash.Encrypt(plainText);
                    break;
                case HashingMethod.SHA1:
                    hashed = SHA1Hash.Encrypt(plainText);
                    break;
                case HashingMethod.SHA256:
                    hashed = SHA256Hash.Encrypt(plainText);
                    break;
                case HashingMethod.SHA384:
                    hashed = SHA384Hash.Encrypt(plainText);
                    break;
                case HashingMethod.SHA512:
                    hashed = SHA512Hash.Encrypt(plainText);
                    break;
                default:
                    throw new Exception("unexpected");
            }
            return hashed;
        }
        public static bool Verify(string plainText, string encryptedText, HashingMethod method)
        {
            var hashed = Hash.Encrypt(plainText, method);
            var strcomparer = StringComparer.OrdinalIgnoreCase;
            return strcomparer.Compare(hashed, encryptedText).Equals(0);
        }
    }
}
