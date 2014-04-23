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
        private readonly SessionHelper helper;

        public AuthenticationFilterAttribute()
        {
            helper = EngineContext.Current.Resolve<SessionHelper>();
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            helper.SetPrincipal(WindowsIdentity.GetCurrent().Name);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}