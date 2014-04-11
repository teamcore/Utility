using System.Web.Http.Filters;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Data.Contract;

namespace Ns.Utility.Web.Framework.Api.Filters
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionAttribute"/> class.
        /// </summary>
        public TransactionAttribute()
        {
            unitOfWork = EngineContext.Current.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Occurs after the action method is invoked.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                unitOfWork.Commit();
            }
        }
    }
}