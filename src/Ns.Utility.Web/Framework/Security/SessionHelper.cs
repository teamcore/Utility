using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Ns.Utility.Web.Framework.Security
{
    public class SessionHelper
    {
        IRepository<User> repository;
        IUnitOfWork unitOfWork;

        public SessionHelper(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void SetPrincipal(string userName)
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

        public GenericIdentity CreateIdentity(string userName, User user)
        {
            var identity = new GenericIdentity(string.IsNullOrEmpty(user.DisplayName) ? userName : user.DisplayName);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.DisplayName));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectName, string.Empty));
            identity.AddClaim(new Claim(SmartClaimTypes.ProjectID, "0"));
            identity.AddClaim(new Claim(SmartClaimTypes.IsAdmin, user.IsAdmin ? bool.TrueString : bool.FalseString));
            return identity;
        }

        public string GetUserName()
        {
            return WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        }
    }
}