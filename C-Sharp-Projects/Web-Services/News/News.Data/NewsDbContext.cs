namespace News.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;

    public class NewsDbContext : IdentityDbContext<User>
    {
        public NewsDbContext()
            : base("NewsConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public DbSet<News> News { get; set; }

        public static NewsDbContext Create()
        {
            return new NewsDbContext();
        }
    }
}
