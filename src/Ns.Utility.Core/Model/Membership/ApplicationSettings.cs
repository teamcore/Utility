using Ns.Utility.Framework.Settings;

namespace Ns.Utility.Core.Model.Membership
{
    public class ApplicationSettings : ISetting
    {
        public static ApplicationSettings Default()
        {
            return new ApplicationSettings
            {
                AppTitle = "Aprimo Utility Application",
                MaxInvalidLoginAttemptCount = 3,
                DefaultPageTitle = "Index",
                DefaultMetaKeywords = "Nirajan Singh",
                DefaultMetaDescription = ".NET Developer",
                PageTitleSeparator = ">>"
            };
        }

        public int MaxInvalidLoginAttemptCount { get; set; }
        public string AppTitle { get; set; }
        public string PageTitleSeparator { get; set; }
        public string DefaultPageTitle { get; set; }
        public string DefaultMetaDescription { get; set; }
        public string DefaultMetaKeywords { get; set; }
    }
}
