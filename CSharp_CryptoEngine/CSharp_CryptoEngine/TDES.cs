using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Honti.CryptoEngine
{
    public class TDES
    {
        public static string Encrypt(string plainText, string passphrase = "1B2c3D4e5F6g7H8")
        {
            byte[] results;
            var UTF8 = new UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
           
            var TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            var dataToEncrypt = UTF8.GetBytes(plainText);

            try
            {
                var Encryptor = TDESAlgorithm.CreateEncryptor();
                results = Encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string Decrypt(string toDecrypt, string passphrase = "1B2c3D4e5F6g7H8")
        {
            byte[] results;
            

            var UTF8 = new UTF8Encoding();

            var hashProvider = new MD5CryptoServiceProvider();
            var TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(passphrase));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            var dataToDecrypt = Convert.FromBase64String(toDecrypt);

            try
            {
                var Decryptor = TDESAlgorithm.CreateDecryptor();
                results = Decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                hashProvider.Clear();
            }

            return UTF8.GetString(results);
        }
    }
}
