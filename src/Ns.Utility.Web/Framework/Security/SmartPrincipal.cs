using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Ns.Utility.Web.Framework.Security
{
    public class SmartPrincipal : ClaimsPrincipal, ISmartPrincipal
    {
        public SmartPrincipal(GenericPrincipal principal) : base(principal.Identities)
        {
            UserName = principal.FindFirst(ClaimTypes.Name).Value;
            DisplayName = principal.FindFirst(ClaimTypes.GivenName).Value;
            ProjectName = principal.FindFirst(SmartClaimTypes.ProjectName).Value;
            //ProjectID = Convert.ToInt32(principal.FindFirst(SmartClaimTypes.ProjectID).Value);
            IsAdmin = bool.Parse(principal.FindFirst(SmartClaimTypes.IsAdmin).Value);
        }
        public string UserName { get; private set; }
        public string DisplayName { get; private set; }
        public bool IsAdmin { get; private set; }
        public string ProjectName { get; private set; }
        public int? ProjectID { get; private set; }
    }
}