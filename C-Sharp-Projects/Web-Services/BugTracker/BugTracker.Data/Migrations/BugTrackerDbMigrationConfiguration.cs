namespace BugTracker.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using BugTracker.Data;

    public sealed class BugTrackerDbMigrationConfiguration : DbMigrationsConfiguration<BugTrackerDbContext>
    {
        public BugTrackerDbMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
