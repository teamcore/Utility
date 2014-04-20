using System.Web;
using System.Web.Optimization;

namespace Ns.Utility.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/2014.1.318/kendo.web.min.js", "~/Scripts/app/kendo.*"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app/smart.*"));
            bundles.Add(new ScriptBundle("~/bundles/grid").Include("~/Scripts/app/grid.*"));
            bundles.Add(new ScriptBundle("~/bundles/project").Include("~/Scripts/app/project.js"));
            bundles.Add(new ScriptBundle("~/bundles/term").Include("~/Scripts/app/term.js"));
            bundles.Add(new ScriptBundle("~/bundles/range").Include("~/Scripts/app/range.js"));
            bundles.Add(new ScriptBundle("~/bundles/resource").Include("~/Scripts/app/resource.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/kendo/2014.1.318/kendo.common-bootstrap.core.min.css",
                "~/Content/kendo/2014.1.318/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2014.1.318/kendo.bootstrap.min.css"));
        }
    }
}
