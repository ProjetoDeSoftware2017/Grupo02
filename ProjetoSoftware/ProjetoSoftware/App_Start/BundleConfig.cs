using System.Web;
using System.Web.Optimization;

namespace ProjetoSoftware
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",                      
                      "~/Scripts/respond.js",
                      "~/Scripts/Chart.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/metisMenu.min.css",
                      "~/Content/css/timeline.css",
                      "~/Content/css/startmin.css",
                      "~/Content/css/morris.css",
                      "~/Content/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
            "~/Content/js/jquery-1.10.2.min.js",
            "~/Content/js/bootstrap.min.js",
            "~/Content/js/metisMenu.min.js",
            "~/Content/js/startmin.js"
            ));
        }
    }
}
