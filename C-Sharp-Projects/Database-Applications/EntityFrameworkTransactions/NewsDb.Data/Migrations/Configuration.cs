namespace NewsDb.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using NewsDb.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDbData>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(NewsDbData context)
        {
            if (!context.News.Any())
            {
                context.News.Add(new News { Content = "New programming basics course on Mars to start next month." });
            }
        }
    }
}
