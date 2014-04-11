using System;
using System.Web.Mvc;
using Ns.Utility.Framework;
using Ns.Utility.Web.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Helper
{
    public static class LayoutExtension
    {
        public static MvcHtmlString AppTitle(this HtmlHelper htmlHelper)
        {
            var titleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            return MvcHtmlString.Create(titleBuilder.GenerateAppTitle());
        }

        public static void AddTitleParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AddTitleParts(parts);
        }

        public static void AppendTitleParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AppendTitleParts(parts);
        }

        public static MvcHtmlString PageTitle(this HtmlHelper htmlHelper, bool addDefaultTitle)
        {
            var titleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            return MvcHtmlString.Create(titleBuilder.GenerateTitle(addDefaultTitle));
        }

        public static void AddMetaDescriptionParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AddMetaDescriptionParts(parts);
        }

        public static void AppendMetaDescriptionParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AppendMetaDescriptionParts(parts);
        }

        public static MvcHtmlString MetaDescription(this HtmlHelper htmlHelper)
        {
            var titleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            return MvcHtmlString.Create(titleBuilder.GenerateMetaDescription());
        }

        public static void AddMetaKeywordParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AddMetaKeywordParts(parts);
        }

        public static void AppendMetaKeywordParts(this HtmlHelper htmlHelper, params string[] parts)
        {
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AppendMetaKeywordParts(parts);
        }

        public static MvcHtmlString MetaKeywords(this HtmlHelper htmlHelper)
        {
            var titleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            return MvcHtmlString.Create(titleBuilder.GenerateMetaKeywords());
        }

        public static void AddBreadCrumbsParts(this HtmlHelper htmlHelper)
        {
            var controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var action = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var area = Convert.ToString(htmlHelper.ViewContext.RouteData.DataTokens["area"]);
            var pageTitleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            pageTitleBuilder.AddBreadCrumbsParts(action, controller, area);
        }

        public static MvcHtmlString BreadCrumbs(this HtmlHelper htmlHelper)
        {
            var controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var action = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var area = Convert.ToString(htmlHelper.ViewContext.RouteData.DataTokens["area"]);
            string key = string.IsNullOrEmpty(area) ? string.Format("/{0}/{1}", controller, action) : string.Format("/{0}/{1}/{2}", area, controller, action);

            var titleBuilder = EngineContext.Current.Resolve<IPageTitleBuilder>();
            return MvcHtmlString.Create(titleBuilder.GenerateBreadCrumbs(key));
        }
    }
}
