namespace NewsDb.Data
{
    using System.Data.Entity;
    using NewsDb.Data.Migrations;
    using NewsDb.Models;

    public class NewsDbData : DbContext
    {
        public NewsDbData()
            : base("NewsDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbData, Configuration>());
        }

        public DbSet<News> News { get; set; }
    }
}
