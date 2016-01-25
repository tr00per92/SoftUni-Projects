using System.Configuration;
using System.Data.SqlClient;
using System.Web.Caching;

namespace MVC_Caching.Migrations
{
    using System.Data.Entity.Migrations;
    using MVC_Caching.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
