using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework;
using Ns.Utility.Web.Framework.Dependency;
using Ns.Utility.Web.Framework.Security;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Ns.Utility.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            EngineContext.Initialize(false, true, new SmartDependencyManager());
            var builder = EngineContext.Current.Builder;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = EngineContext.Build();
            var apiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_BeginRequest()
        {
            
        }
    }
}
