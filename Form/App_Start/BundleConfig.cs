using System.Web;
using System.Web.Optimization;

namespace Form
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        /*"~/Scripts/jquery-{version}.js")*/
                        "~/Scripts/jquery.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));


            //Bootstrap core Javascript
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    //"~/Scripts/bootstrap.min.js",
                    "~/Content/Template/vendor/jquery/jquery.min.js",
                    "~/Content/Template/vendor/bootstrap/js/bootstrap.bundle.min.js"
                    ));

            //Core plugin JavaScript
            bundles.Add(new ScriptBundle("~/Template/jquery").Include(
                    //"~/Content/Template/vendor/jquery/jquery.min.js",
                    "~/Content/Template/vendor/jquery-easing/jquery.easing.min.js"));

            //Custom scripts for all page
            bundles.Add(new ScriptBundle("~/Template/Script").Include(
                    "~/Content/sweetalert2/sweetalert2.min.js",
                    "~/Scripts/bootstrap-table.min.js",
                    "~/Content/Template/js/sb-admin-2.min.js"));

            //Page Login script
            bundles.Add(new ScriptBundle("~/bundles/LoginScript").Include(
                    "~/Scripts/login.js"));

            //Page Customer script
            bundles.Add(new ScriptBundle("~/bundles/CustomerScript").Include(
                    "~/Scripts/customer.js"));




            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      //"~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-table.min.css"));
                      

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/sweetalert2/sweetalert2.min.css"));

            bundles.Add(new StyleBundle("~/Template/css").Include(
                "~/Content/Template/vendor/fontawesome-free/css/all.min.css",
                "~/Content/Template/css/sb-admin-2.min.css"));

        }
    }
}
