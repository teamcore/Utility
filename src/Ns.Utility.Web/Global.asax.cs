using Autofac;
using Autofac.Integration.WebApi;
using Ns.Utility.Framework;
using Ns.Utility.Web.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ns.Utility.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            EngineContext.Initialize(false, true, new SmartDependencyManager());
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = EngineContext.Current.Builder;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var resolver = new AutofacWebApiDependencyResolver(EngineContext.Current.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
