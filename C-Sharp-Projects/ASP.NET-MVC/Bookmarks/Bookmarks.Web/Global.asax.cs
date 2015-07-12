﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bookmarks.Common.Mappings;
using Bookmarks.Data;
using Bookmarks.Data.Migrations;

namespace Bookmarks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, DefaultConfiguration>());
            ViewEnginesConfig.RegisterViewEngines();
            AutoMapperConfig.Execute(new[] { Assembly.GetExecutingAssembly() });
        }
    }
}
