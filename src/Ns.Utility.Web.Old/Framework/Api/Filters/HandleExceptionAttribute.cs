using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Filters;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Logger;

namespace Ns.Utility.Web.Framework.Api.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public HandleExceptionAttribute()
        {
            logger = EngineContext.Current.Resolve<ILogger>();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                logger.InsertLog(LogLevel.Error, exception.Message, exception.StackTrace, Thread.CurrentPrincipal.Identity.Name);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception.Message, exception);
            }
        }
    }
}
