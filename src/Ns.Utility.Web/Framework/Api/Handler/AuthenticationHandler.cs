using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.Security;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework.Exceptions;
using System.Security.Principal;
using System.Security.Claims;
using System.Web;
using Ns.Utility.Web.Framework.Security;

namespace Ns.Utility.Web.Framework.Api.Handler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IRepository<User> repository;

        public AuthenticationHandler()
        {
            repository = EngineContext.Current.Resolve<IRepository<User>>();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetPrincipal(WindowsIdentity.GetCurrent().Name);
            return base.SendAsync(request, cancellationToken);
        }


        private void SetPrincipal(string userName)
        {
            var authParam = userName.Split('\\');
            var domain = authParam[0];
            var loginID = authParam[1];
            var user = repository.FindOne(x => x.UserName == loginID && x.Domain == domain);
            if(user == null)
            {
                user = new UserFactory().CreateUser(domain, loginID);
                repository.Add(user);
            }

            var identity = CreateIdentity(loginID, user);
            var principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            if(HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private GenericIdentity CreateIdentity(string userName, User user)
        {
            var identity = new GenericIdentity(userName);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.DisplayName));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectName, string.Empty));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectID, string.Empty));
            identity.AddClaim(new Claim(SmartClaimTypes.IsAdmin, user.IsAdmin ? bool.TrueString : bool.FalseString));
            return identity;
        }
    }
}
