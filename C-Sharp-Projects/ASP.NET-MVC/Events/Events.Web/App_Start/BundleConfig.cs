namespace Events.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
                "~/Scripts/moment.*",
                "~/Scripts/bootstrap-datetimepicker*",
                "~/Scripts/timepickers.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datetimepicker").Include(
                "~/Content/bootstrap-datetimepicker.min.css"));
        }
    }
}