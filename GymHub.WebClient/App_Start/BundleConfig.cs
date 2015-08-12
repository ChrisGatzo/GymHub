using System.Web.Optimization;

namespace GymHub.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/libs/jquery/jquery-{version}.js",
                "~/Scripts/libs/jquery/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/libs/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                "~/Scripts/libs/jquery/jquery.form*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/libs/bootstrap/bootstrap.js",
                "~/Scripts/libs/respond/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                "~/Scripts/libs/toastr/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/libs/DataTables-1.10.1/media/js/jquery.dataTables.js",
                "~/Scripts/libs/DataTables-1.10.1/media/js/dataTables.bootstrap.js",
                "~/Scripts/libs/DataTables-1.10.1/extensions/Responsive/js/dataTables.responsive.js",
                "~/Scripts/libs/DataTables-1.10.1/extensions/FixedColumns/js/dataTables.fixedColumns.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/general").Include(
                "~/Scripts/app/strings.js",
                "~/Scripts/app/ajax-handler.js",
                "~/Scripts/app/data-service.js",
                "~/Scripts/app/stacktrace.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/workoutoftheday").Include(            
                "~/Scripts/app/workout-of-the-day.js"));

            bundles.Add(new ScriptBundle("~/bundles/diet").Include(
                "~/Scripts/app/diet.js"));

            bundles.Add(new ScriptBundle("~/bundles/statistics").Include(
                "~/Scripts/app/statistics.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/DataTables-1.10.1/media/css/dataTables.bootstrap.css",
                "~/Content/DataTables-1.10.1/extensions/Responsive/css/dataTables.responsive.css",
                "~/Content/toastr/toastr.css",
                "~/Content/Site.css"));

        }
    }
}
