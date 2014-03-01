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
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/i18n/angular-locale_en-us.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularui").Include(
                       "~/Scripts/ui-bootstrap-{version}.js",
                       "~/Scripts/ui-bootstrap-tpls-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/app.js",
                //"~/Scripts/app/filters/*.js",
                //"~/Scripts/app/directives/*.js",
                "~/Scripts/app/services/*.js",
                "~/Scripts/app/controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Scripts/angular-csp.css",
                      "~/Content/angular-ui.css",
                      "~/Content/select2.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
