using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Ns.Utility.Web.Framework.Mvc
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationFilterAttribute()
        {
            repository = EngineContext.Current.Resolve<IRepository<User>>();
            unitOfWork = EngineContext.Current.Resolve<IUnitOfWork>();
        }

        private void SetPrincipal(string userName)
        {
            var authParam = userName.Split('\\');
            var domain = authParam[0];
            var loginID = authParam[1];
            var user = repository.FindOne(x => x.UserName == loginID && x.Domain == domain);
            if (user == null)
            {
                user = new UserFactory().CreateUser(domain, loginID);
                repository.Add(user);
                unitOfWork.Commit();
            }

            var identity = CreateIdentity(loginID, user);
            var principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private GenericIdentity CreateIdentity(string userName, User user)
        {
            var identity = new GenericIdentity(string.IsNullOrEmpty(user.DisplayName) ? userName : user.DisplayName);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.DisplayName));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectName, string.Empty));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectID, string.Empty));
            identity.AddClaim(new Claim(SmartClaimTypes.IsAdmin, user.IsAdmin ? bool.TrueString : bool.FalseString));
            return identity;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            SetPrincipal(WindowsIdentity.GetCurrent().Name);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}