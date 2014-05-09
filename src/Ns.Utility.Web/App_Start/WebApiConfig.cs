using Ns.Utility.Web.Framework.Api.Filters;
using Ns.Utility.Web.Framework.Api.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Ns.Utility.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new AuthenticationHandler());
            config.Services.Replace(typeof(IExceptionHandler), new SmartExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
