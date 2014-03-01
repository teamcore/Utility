using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Framework.Fakes
{
    public class FakeHttpRequest : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;
        private readonly NameValueCollection formParams;
        private readonly NameValueCollection queryStringParams;
        private readonly NameValueCollection serverVariables;
        private readonly string relativeUrl;
        private readonly Uri url;
        private readonly Uri urlReferrer;
        private readonly string httpMethod;

        public FakeHttpRequest(string relativeUrl, string method, NameValueCollection formParams, NameValueCollection queryStringParams,
                               HttpCookieCollection cookies)
        {
            httpMethod = method;
            this.relativeUrl = relativeUrl;
            this.formParams = formParams;
            this.queryStringParams = queryStringParams;
            this.cookies = cookies;
            serverVariables = new NameValueCollection();
        }

        public FakeHttpRequest(string relativeUrl, string method, Uri url, Uri urlReferrer, NameValueCollection formParams, NameValueCollection queryStringParams,
                               HttpCookieCollection cookies)
            : this(relativeUrl, method, formParams, queryStringParams, cookies)
        {
            this.url = url;
            this.urlReferrer = urlReferrer;
        }

        public FakeHttpRequest(string relativeUrl, Uri url, Uri urlReferrer)
            : this(relativeUrl, HttpVerbs.Get.ToString("g"), url, urlReferrer, null, null, null)
        {
        }

        public override NameValueCollection ServerVariables
        {
            get
            {
                return serverVariables;
            }
        }

        public override NameValueCollection Form
        {
            get { return formParams; }
        }

        public override NameValueCollection QueryString
        {
            get { return queryStringParams; }
        }

        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get { return relativeUrl; }
        }

        public override Uri Url
        {
            get
            {
                return url;
            }
        }

        public override Uri UrlReferrer
        {
            get
            {
                return urlReferrer;
            }
        }

        public override string PathInfo
        {
            get { return String.Empty; }
        }

        public override string ApplicationPath
        {
            get
            {
                return "";
            }
        }

        public override string HttpMethod
        {
            get
            {
                return httpMethod;
            }
        }
    }
}