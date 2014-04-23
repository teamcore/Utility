using Ns.Utility.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Framework.Mvc
{
    public class UtilityController : Controller
    {
        public IUserSession UserSession { get { return new UserSession(HttpContext.User as ClaimsPrincipal); } }
    }
}