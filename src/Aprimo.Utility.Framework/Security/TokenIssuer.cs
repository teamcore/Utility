using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Framework.Security
{
    public class TokenIssuer
    {
        private Dictionary<string, string> audienceKeys = new Dictionary<string, string>();

        // This method is called to register a key with the token issuer against an audience or an RP
        public void ShareKeyOutofBand(string audience, string key)
        {
            if (!audienceKeys.ContainsKey(audience))
                audienceKeys.Add(audience, key);
            else
                audienceKeys[audience] = key;
        }

        public string GetToken(string audience, string credentials)
        {
            JsonWebToken token = new JsonWebToken()
            {
                SymmetricKey = audienceKeys[audience],
                Issuer = "TokenIssuer",
                Audience = audience
            };

            token.AddClaim(ClaimTypes.Name, credentials);
            
            return token.ToString();
        }

        public string GetEncryptedToken(string audience, string credentials)
        {
            JsonWebEncryptedToken token = new JsonWebEncryptedToken()
            {
                AsymmetricKey = audienceKeys[audience],
                Issuer = "TokenIssuer",
                Audience = audience
            };

            token.AddClaim(ClaimTypes.Name, credentials);

            return token.ToString();
        }

        public static Tuple<string, string> GenerateAsymmetricKey()
        {
            string publicKey = String.Empty;
            string privateKey = String.Empty;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
            }
            return new Tuple<string, string>(publicKey, privateKey);
        }
    }
}
