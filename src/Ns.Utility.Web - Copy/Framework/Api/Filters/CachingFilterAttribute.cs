using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ns.Utility.Framework.Caching;

namespace Ns.Utility.Web.Framework.Api.Filters
{
    public class CachingFilterAttribute : ActionFilterAttribute
    {
        private readonly ICacheProvider cacheProvider;
        private string cacheKey;
        private string cacheKeyPattern;
        private Action<HttpActionExecutedContext> callback;

        public CachingFilterAttribute(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            var keyPart = string.Empty;
            var model = actionContext.ActionArguments;
            if(model.Count > 0)
            {
                foreach (var key in model.Keys)
                {
                    if(string.IsNullOrEmpty(keyPart))
                    {
                        keyPart += string.Format("{0}.{1}", key, Convert.ToString(model[key]));
                        continue;
                    }

                    keyPart += string.Format("/{0}.{1}", key, Convert.ToString(model[key]));    
                }
            }
            else
            {
                keyPart = "all";
            }

            var absolutePath = actionContext.Request.RequestUri.AbsolutePath;
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            cacheKeyPattern = string.Format("/api/{0}", controllerName);

            HttpMethod method = actionContext.Request.Method;
            if(method == HttpMethod.Get)
            {
                cacheKey = string.Join(":", new[] { absolutePath, keyPart });

                if(cacheProvider.IsSet(cacheKey))
                {
                    var cachedValue = cacheProvider.Get<Task<string>>(cacheKey);
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted, cachedValue);
                }

                callback = actionExecutedContext =>
                {
                    Task<string> output = actionExecutedContext.Response.Content.ReadAsStringAsync();
                    cacheProvider.Set(cacheKey, output, new CacheItemPolicy());
                };
            }
            else
            {
                cacheProvider.RemoveByPattern(cacheKeyPattern);
            }

            //base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
            {
                throw new ArgumentNullException("actionExecutedContext");
            }

            callback(actionExecutedContext);

            //base.OnActionExecuted(actionExecutedContext);
        }
    }
}
