using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Test_Bindle.Areas.Admin.App_Star_Admin
{
    public class BundleAdminConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/admin/bundles/chartjs.min").Include(
                "~/Areas/Admin/js/chartjs.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/dashboard").Include(
                "~/Areas/Admin/js/dashboard.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/less.min").Include(
                "~/Areas/Admin/js/less.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/main").Include(
                "~/Areas/Admin/js/main.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/plugins").Include(
                "~/Areas/Admin/js/plugins.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/popper.min").Include(
                "~/Areas/Admin/js/popper.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/selectFx").Include(
                "~/Areas/Admin/js/selectFx.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/widgets").Include(
                "~/Areas/Admin/js/widgets.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/vendor/jquery-1.11.3.min").Include(
                "~/Areas/Admin/js/vendor/jquery-1.11.3.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/jquery-2.1.4.min").Include(
                "~/Areas/Admin/js/jquery-2.1.4.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/modernizr-2.8.3.min").Include(
                "~/Areas/Admin/js/modernizr-2.8.3.min.js"));

        }
    }
}