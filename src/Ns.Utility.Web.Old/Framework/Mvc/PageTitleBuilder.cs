using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ns.Utility.Framework;
using Ns.Utility.Framework.Settings;
using Ns.Utility.Core.Model.Membership;

namespace Ns.Utility.Web.Framework.Mvc
{
    public class PageTitleBuilder : IPageTitleBuilder
    {
        private readonly ApplicationSettings appSettings;
        private readonly List<string> titleParts;
        private readonly List<string> metaDescriptionParts;
        private readonly List<string> metaKeywordParts;
        private readonly Dictionary<string, string> breadcrumbsParts;

        public PageTitleBuilder()
        {
            var provider = EngineContext.Current.Resolve<IConfigurationProvider<ApplicationSettings>>();
            appSettings = provider.Settings;
            titleParts = new List<string>();
            metaDescriptionParts = new List<string>();
            metaKeywordParts = new List<string>();
            breadcrumbsParts = new Dictionary<string, string>();
        }

        public string GenerateAppTitle()
        {
            return appSettings.AppTitle;
        }

        public void AddTitleParts(params string[] parts)
        {
            if (parts != null)
            {
                titleParts.Clear();
                foreach (string part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        titleParts.Add(part);
                    }
                }
            }
        }

        public void AppendTitleParts(params string[] parts)
        {
            if (parts != null)
            {
                titleParts.Clear();
                foreach (string part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        titleParts.Insert(0, part);
                    }
                }
            }

        }
        public string GenerateTitle(bool addDefaultTitle)
        {
            string result;
            var specificTitle = string.Join(appSettings.PageTitleSeparator, titleParts.AsEnumerable().Reverse().ToArray());
            if (!String.IsNullOrEmpty(specificTitle))
            {
                result = addDefaultTitle ? string.Join(appSettings.PageTitleSeparator, specificTitle, appSettings.DefaultPageTitle) : specificTitle;
            }
            else
            {
                result = appSettings.DefaultPageTitle;
            }

            return result;
        }


        public void AddMetaDescriptionParts(params string[] parts)
        {
            if (parts != null)
                foreach (string part in parts)
                    if (!string.IsNullOrEmpty(part))
                        metaDescriptionParts.Add(part);
        }
        public void AppendMetaDescriptionParts(params string[] parts)
        {
            if (parts != null)
                foreach (string part in parts)
                    if (!string.IsNullOrEmpty(part))
                        metaDescriptionParts.Insert(0, part);
        }
        public string GenerateMetaDescription()
        {
            var metaDescription = string.Join(", ", metaDescriptionParts.AsEnumerable().Reverse().ToArray());
            var result = !String.IsNullOrEmpty(metaDescription) ? metaDescription : appSettings.DefaultMetaDescription;
            return result;
        }


        public void AddMetaKeywordParts(params string[] parts)
        {
            if (parts != null)
                foreach (string part in parts)
                    if (!string.IsNullOrEmpty(part))
                        metaKeywordParts.Add(part);
        }
        public void AppendMetaKeywordParts(params string[] parts)
        {
            if (parts != null)
                foreach (string part in parts)
                    if (!string.IsNullOrEmpty(part))
                        metaKeywordParts.Insert(0, part);
        }
        public string GenerateMetaKeywords()
        {
            var metaKeyword = string.Join(", ", metaKeywordParts.AsEnumerable().Reverse().ToArray());
            var result = !String.IsNullOrEmpty(metaKeyword) ? metaKeyword : appSettings.DefaultMetaKeywords;
            return result;
        }

        public void AddBreadCrumbsParts(string actionName, string controllerName, string areaName)
        {
            string key = string.IsNullOrEmpty(areaName) ? string.Format("/{0}/{1}", controllerName, actionName) : string.Format("/{0}/{1}/{2}", areaName, controllerName, actionName);
            string value = string.Format("{0}-{1}", controllerName, actionName);
            if (!breadcrumbsParts.ContainsKey(key))
            {
                breadcrumbsParts.Add(key, value);
            }
        }

        public string GenerateBreadCrumbs(string key)
        {
            string breadCrumbs = string.Empty;
            bool matchFound = false;
            int index = 0;
            var removeList = new List<string>();
            foreach (var part in breadcrumbsParts)
            {
                if (!matchFound)
                {
                    if (part.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        breadCrumbs += string.Format("<li class=\"active\">{0}</li>", part.Value);
                        matchFound = true;
                        continue;
                    }

                    breadCrumbs += string.Format("<li><a href=\"{0}\">{1}</a></li>", part.Key, part.Value);
                }

                if (matchFound && index > 0)
                {
                    removeList.Add(part.Key);
                }
                
                index++;
            }

            foreach (var item in removeList)
            {
                breadcrumbsParts.Remove(item);
            }

            return breadCrumbs;
        }
    }
}
