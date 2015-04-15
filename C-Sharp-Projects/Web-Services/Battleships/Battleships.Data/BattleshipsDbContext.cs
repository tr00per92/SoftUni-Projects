namespace Battleships.Data
{
    using System.Data.Entity;
    using Battleships.Data.Migrations;
    using Battleships.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BattleshipsDbContext : IdentityDbContext<ApplicationUser>
    {
        public BattleshipsDbContext()
            : base("BattleshipsConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleshipsDbContext, Configuration>());
        }

        public static BattleshipsDbContext Create()
        {
            return new BattleshipsDbContext();
        }

        public IDbSet<Game> Games { get; set; }
    }
}
