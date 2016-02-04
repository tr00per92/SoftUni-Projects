namespace Photography.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Photography.Common.Mappings;
    using Photography.Data;
    using Photography.Data.Migrations;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographyDbContext, DefaultConfiguration>());
            ViewEnginesConfig.RegisterViewEngines();
            AutoMapperConfig.Execute(new[] { Assembly.GetExecutingAssembly() });
        }
    }
}