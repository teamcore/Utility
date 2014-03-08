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

namespace Ns.Utility.Web.Framework.Api.Handler
{
    public class AuthTokenValidationHandler : DelegatingHandler
    {
        private readonly IRepository<User> repository;

        public AuthTokenValidationHandler()
        {
            repository = EngineContext.Current.Resolve<IRepository<User>>();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token;

            try
            {
                //if (!IsValidDateTime(request.Headers.Date.Value.UtcDateTime))
                //{
                //    throw new  FunctionalException("Stale http request");
                //}

                token = request.Headers.GetValues(GlobalConstants.AuthToken).FirstOrDefault();
            }
            catch (InvalidOperationException)
            {
                return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Missing Authorization-Token")
                    });
            }

            try
            {
                //var authToken = SecurityHelper.Decrypt(token, GlobalConstants.PrivateKey);
                //var authTokenArr = authToken.Split('|');
                //var userId = Convert.ToInt32(authTokenArr[0]);
                //var accessKey = authTokenArr[1];
                //User user = repository.AsQueryable().FirstOrDefault(x => x.Id == userId);
                //if (user == null)
                    return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.Forbidden)
                        {
                            Content = new StringContent("Unauthorized User")
                        });
            }
            catch (RsaCryptoException)
            {
                return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent("Error encountered while attempting to process authorization token")
                    });
            }

            return base.SendAsync(request, cancellationToken);
        }

        public bool IsValidDateTime(DateTimeOffset date)
        {
            var utcNow = DateTime.UtcNow;
            return date < utcNow.AddMinutes(5) && date > utcNow.AddMinutes(-5);
        }
    }
}
