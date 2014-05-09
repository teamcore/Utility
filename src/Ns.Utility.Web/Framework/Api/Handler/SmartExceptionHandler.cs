using Ns.Utility.Framework;
using Ns.Utility.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Ns.Utility.Web.Framework.Api.Handler
{
    public class SmartExceptionHandler : ExceptionHandler
    {
        private readonly ILogger logger;

        public SmartExceptionHandler()
        {
            logger = EngineContext.Current.Resolve<ILogger>();
        }

        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if(context.Exception != null)
            {
                var exception = context.Exception;
                logger.InsertLog(LogLevel.Error, exception.Message, exception.StackTrace, Thread.CurrentPrincipal.Identity.Name);

                if (exception is DbUpdateConcurrencyException)
                {
                    context.Result = new OkResult(context.Request);
                }
                else
                {
                    context.Result = new InternalServerErrorResult(context.ExceptionContext.Request);
                }
            }

            return base.HandleAsync(context, cancellationToken);
        }
    }
}