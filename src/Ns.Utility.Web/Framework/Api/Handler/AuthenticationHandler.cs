using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.Security;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework.Exceptions;
using System.Security.Principal;
using System.Security.Claims;
using System.Web;
using Ns.Utility.Web.Framework.Security;

namespace Ns.Utility.Web.Framework.Api.Handler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly SessionHelper helper;

        public AuthenticationHandler()
        {
            helper = EngineContext.Current.Resolve<SessionHelper>();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            helper.SetPrincipal(WindowsIdentity.GetCurrent().Name);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
