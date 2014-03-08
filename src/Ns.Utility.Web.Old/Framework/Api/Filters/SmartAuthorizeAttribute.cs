using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Ns.Utility.Web.Framework.Api.Filters
{
    public class SmartAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.GetValues("authenticationToken") != null)
            {
                // get value from header
                string authenticationToken = Convert.ToString(actionContext.Request.Headers.GetValues("authenticationToken").FirstOrDefault());
                string authenticationTokenPersistant = string.Empty;
                //authenticationTokenPersistant
                // it is saved in some data store
                // i will compare the authenticationToken sent by client with
                // authenticationToken persist in database against specific user, and act accordingly
                if (authenticationTokenPersistant != authenticationToken)
                {
                    HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                    return;
                }

                HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                return;
            }
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            actionContext.Response.ReasonPhrase = "Please provide valid inputs";
        }
    }
}
