namespace Ns.Utility.Web.Framework.Mvc
{
    public interface IPageTitleBuilder
    {
        string GenerateAppTitle();
        void AddTitleParts(params string[] parts);
        void AppendTitleParts(params string[] parts);
        string GenerateTitle(bool addDefaultTitle);

        void AddMetaDescriptionParts(params string[] parts);
        void AppendMetaDescriptionParts(params string[] parts);
        string GenerateMetaDescription();

        void AddMetaKeywordParts(params string[] parts);
        void AppendMetaKeywordParts(params string[] parts);
        string GenerateMetaKeywords();

        void AddBreadCrumbsParts(string actionName, string controllerName, string areaName);
        string GenerateBreadCrumbs(string key);
    }
}
