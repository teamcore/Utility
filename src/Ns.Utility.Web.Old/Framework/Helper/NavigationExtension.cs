using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ns.Utility.Web.Framework.Helper
{
    public static class NavigationExtension
    {
        public static MvcHtmlString BuildUrl(this HtmlHelper html, string relativeUrl)
        {
            string baseUrl = string.Empty;
            var context = html.ViewContext.HttpContext;
            if (context != null && context.Request != null && context.Request.Url != null)
            {
                baseUrl = context.Request.Url.AbsoluteUri.Replace(context.Request.RawUrl, "");
                var urlFormat = relativeUrl.StartsWith("/") ? "{0}{1}" : "{0}/{1}";
                baseUrl = string.Format(urlFormat, baseUrl, relativeUrl);
            }

            return MvcHtmlString.Create(baseUrl);
        }

        public static MvcHtmlString ResolveUrl(this HtmlHelper htmlHelper, string url)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            return MvcHtmlString.Create(urlHelper.Content(url));
        }

        public static MvcHtmlString ActionLinkIcon(this MvcHtmlString htmlString, string className)
        {
            var html = htmlString.ToHtmlString();
            var position = html.IndexOf('>');
            if (position > 0)
            {
                html = html.Insert(position + 1, String.Format("<i class=\"{0}\"></i> ", className));
            }

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString ActiveActionLink(this HtmlHelper html, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
        {
            var tag = new TagBuilder("li");
            var controller = html.ViewContext.RouteData.Values["Controller"].ToString();
            var action = html.ViewContext.RouteData.Values["Action"].ToString();
            if (controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase) && action.Equals(actionName, StringComparison.OrdinalIgnoreCase))
            {
                tag.MergeAttribute("class", "active");
            }

            tag.InnerHtml = html.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}