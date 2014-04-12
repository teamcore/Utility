using Autofac;
using Autofac.Integration.WebApi;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework;
using Ns.Utility.Web.Framework.Dependency;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
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
            var builder = EngineContext.Current.Builder;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = EngineContext.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }

        protected void Session_OnStart()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            var user = currentUser.Name.Split('\\');
            string domain = user[0];
            string userName = user[1];
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new Uri("http://localhost:2043/");
                var response = client.GetAsync(string.Format("api/users/exists/{0}/{1}", domain, userName)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<bool>();
                    if (!result.Result)
                    {
                        var model = new UserModel { Domain = domain, UserName = userName };
                        var resp = client.PostAsJsonAsync<UserModel>("api/users", model).Result;
                    }
                }
            }
        }

        protected void Session_OnEnd()
        {
            // Session clean-up code goes here.
        }

        protected void Application_OnAuthenticateRequest(object source, EventArgs e)
        {
            // Authentication code goes here.
        }

        protected async Task RunAsync(string userName)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new Uri("http://localhost:2043/");
                var response = await client.GetAsync(string.Format("api/users/{0}", userName));
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadAsAsync<UserModel>();
                }
            }
        }
    }
}
