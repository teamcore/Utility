using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Ns.Utility.Web.Framework.Api.ActionResults
{
    public class ModelActionResult<TModel> : IHttpActionResult
    {
        private TModel model;
        private HttpRequestMessage request;
        public ModelActionResult(TModel model, HttpRequestMessage request)
        {
            this.model = model;
            this.request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = request.CreateResponse<TModel>(HttpStatusCode.OK, model);
            return Task.FromResult(response);
        }
    }
}