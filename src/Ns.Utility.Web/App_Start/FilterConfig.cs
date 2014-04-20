using Ns.Utility.Web.Framework.Mvc;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationFilterAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
