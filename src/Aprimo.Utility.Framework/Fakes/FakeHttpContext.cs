using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace Aprimo.Utility.Framework.Fakes
{
    public class FakeHttpContext : HttpContextBase
    {
        private readonly HttpCookieCollection cookies;
        private readonly NameValueCollection formParams;
        private IPrincipal principal;
        private readonly NameValueCollection queryStringParams;
        private readonly string relativeUrl;
        private readonly string method;
        private readonly SessionStateItemCollection sessionItems;
        private HttpResponseBase response;
        private HttpRequestBase request;
        private readonly Dictionary<object, object> items;

        public static FakeHttpContext Root()
        {
            return new FakeHttpContext("~/");
        }

        public FakeHttpContext(string relativeUrl, string method)
            : this(relativeUrl, method, null, null, null, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl) 
            : this(relativeUrl, null, null, null, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl, IPrincipal principal, NameValueCollection formParams,
                               NameValueCollection queryStringParams, HttpCookieCollection cookies,
                               SessionStateItemCollection sessionItems) 
            : this(relativeUrl, null, principal, formParams, queryStringParams, cookies, sessionItems)
        {
        }

        public FakeHttpContext(string relativeUrl, string method, IPrincipal principal, NameValueCollection formParams,
                               NameValueCollection queryStringParams, HttpCookieCollection cookies,
                               SessionStateItemCollection sessionItems)
        {
            this.relativeUrl = relativeUrl;
            this.method = method;
            this.principal = principal;
            this.formParams = formParams;
            this.queryStringParams = queryStringParams;
            this.cookies = cookies;
            this.sessionItems = sessionItems;

            items = new Dictionary<object, object>();
        }

        public override HttpRequestBase Request
        {
            get
            {
                return request ??
                       new FakeHttpRequest(relativeUrl, method, formParams, queryStringParams, cookies);
            }
        }

        public void SetRequest(HttpRequestBase request)
        {
            this.request = request;
        }

        public override HttpResponseBase Response
        {
            get
            {
                return response ?? new FakeHttpResponse();
            }
        }

        public void SetResponse(HttpResponseBase response)
        {
            this.response = response;
        }

        public override IPrincipal User
        {
            get { return principal; }
            set { principal = value; }
        }

        public override HttpSessionStateBase Session
        {
            get { return new FakeHttpSessionState(sessionItems); }
        }

        public override System.Collections.IDictionary Items
        {
            get
            {
                return items;
            }
        }


        public override bool SkipAuthorization { get; set; }

        public override object GetService(Type serviceType)
        {
            return null;
        }
    }
}