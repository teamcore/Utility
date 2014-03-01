using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Ns.Utility.Framework.Exceptions;

namespace Ns.Utility.Framework.Security
{
    public class SecurityHelper
    {
        private static RSACryptoServiceProvider rsaKeyprovider;

        static SecurityHelper()
        {
            rsaKeyprovider = new RSACryptoServiceProvider();
        }

        private static readonly UnicodeEncoding encoder = new UnicodeEncoding();

        public static string Decrypt(string data, string privateKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                var dataArray = data.Split(new[] { ',' });
                var dataByte = new byte[dataArray.Length];
                for (int i = 0; i < dataArray.Length; i++)
                {
                    dataByte[i] = Convert.ToByte(dataArray[i]);
                }

                rsa.FromXmlString(privateKey);
                var decryptedByte = rsa.Decrypt(dataByte, false);
                return encoder.GetString(decryptedByte);
            }
            catch (Exception exception)
            {
                throw new RsaCryptoException("Error while decrypting data", exception);
            }
        }

        public static string Encrypt(string data, string publicKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publicKey);
                var dataToEncrypt = encoder.GetBytes(data);
                var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
                var length = encryptedByteArray.Count();
                var item = 0;
                var sb = new StringBuilder();
                foreach (var x in encryptedByteArray)
                {
                    item++;
                    sb.Append(x);

                    if (item < length)
                        sb.Append(",");
                }

                return sb.ToString();
            }
            catch (Exception exception)
            {
                throw new RsaCryptoException("Error while encrypting data", exception);
            }
        }

        public static string GetPublicKey()
        {
            //Export private parameter XML representation of publicParameters
            //object created above
            return rsaKeyprovider.ToXmlString(false);
        }

        public static string GetPrivateKey()
        {
            //Export private parameter XML representation of privateParameters
            //object created above
            return rsaKeyprovider.ToXmlString(true);
        }
    }
}
