using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;

namespace Ns.Utility.Web.Areas.Deployment.Controllers.Api
{
    [RoutePrefix("api/buildprocess")]
    public class BuildProcessController : ApiController
    {
        [Route("{buildName}")]
        public HttpResponseMessage Get(string buildName)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ProgressWebSocketHandler(buildName));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);

            //if (HttpContext.Current.IsWebSocketRequest)
            //{
            //    HttpContext.Current.AcceptWebSocketRequest(new ProgressWebSocketHandler(buildName));
            //    return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            //}

            //return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        
        private class ProgressWebSocketHandler : WebSocketHandler
        {
            private static WebSocketCollection client = new WebSocketCollection();
            private string buildName;

            public ProgressWebSocketHandler(string buildName)
            {
                this.buildName = buildName;
            }

            public override void OnOpen()
            {
                client.Add(this);
            }

            public override void OnMessage(string message)
            {
                client.Broadcast(message);
            }
        }
    }
}
