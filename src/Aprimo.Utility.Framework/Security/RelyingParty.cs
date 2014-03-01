using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprimo.Utility.Framework.Security
{
    public class RelyingParty
    {
        private string secretKey = String.Empty;

        public void ShareKeyOutofBand(string key)
        {
            this.secretKey = key;
        }

        public void Authenticate(string token)
        {
            JsonWebToken jwt = null;
            try
            {
                jwt = JsonWebToken.Parse(token, this.secretKey);
                Thread.CurrentPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "JWT"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AuthenticateWithEncryptedToken(string token)
        {
            JsonWebEncryptedToken jwt = null;
            try
            {
                jwt = JsonWebEncryptedToken.Parse(token, this.secretKey);
                Thread.CurrentPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "JWT"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void TheMethodRequiringAuthZ()
        {
            Console.WriteLine("With great power comes great responsibility - Uncle Ben");
        }
    }
}
