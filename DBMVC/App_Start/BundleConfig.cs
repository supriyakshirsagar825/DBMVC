using System.Web;
using System.Web.Optimization;

namespace DBMVC
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            //Bundle b = new ScriptBundle("~/Supriya/Bundle/js");
            //b.Include("~/Areas/Admin/NewFolder1/one.js",
            //    "~/Areas/Admin/NewFolder1/two.js",
            //    "~/Areas/Admin/NewFolder1/three.js",
            //    "~/Areas/Admin/NewFolder1/four.js",
            //    "~/Areas/Admin/NewFolder1/five.js",
            //    "~/Areas/Admin/NewFolder1/six.js");
            //bundles.Add(b);

            bundles.Add(new ScriptBundle("~/Supriya1/Bundle/js").IncludeDirectory("~/Areas/Admin/NewFolder1", "*.js"));
            bundles.Add(new StyleBundle("~/SupriyaK/Bundle/style").IncludeDirectory("~/Areas/Admin/NewFolder1", "*.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}

