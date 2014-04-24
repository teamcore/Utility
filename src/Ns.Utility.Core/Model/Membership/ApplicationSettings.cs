using Ns.Utility.Framework.Settings;

namespace Ns.Utility.Core.Model.Membership
{
    public class ApplicationSettings : ISetting
    {
        public bool IsDefaultOrEmpty()
        {
            return string.IsNullOrEmpty(AppTitle)
                && string.IsNullOrEmpty(PageTitleSeparator)
                && string.IsNullOrEmpty(DefaultPageTitle)
                && string.IsNullOrEmpty(DefaultMetaKeywords)
                && string.IsNullOrEmpty(DefaultMetaDescription)
                && MaxInvalidLoginAttemptCount == 0;
        }

        public static ApplicationSettings Default()
        {
            return new ApplicationSettings
            {
                AppTitle = "Aprimo Utility",
                MaxInvalidLoginAttemptCount = 3,
                DefaultPageTitle = "Index",
                DefaultMetaKeywords = "Nirajan Singh",
                DefaultMetaDescription = ".NET Developer",
                PageTitleSeparator = ">>",
                SoftDeleteEnabled = true
            };
        }

        public int MaxInvalidLoginAttemptCount { get; set; }
        public string AppTitle { get; set; }
        public string PageTitleSeparator { get; set; }
        public string DefaultPageTitle { get; set; }
        public string DefaultMetaDescription { get; set; }
        public string DefaultMetaKeywords { get; set; }
        public bool SoftDeleteEnabled { get; set; }
    }
}
