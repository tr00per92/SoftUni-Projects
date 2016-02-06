namespace SportSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportSystem.Models;

    public class SportSystemDbContext : IdentityDbContext<User>, ISportSystemDbContext
    {
        public SportSystemDbContext()
            : base("SportSystemConnection", false)
        {
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(t => t.AwayMatches).WithRequired(m => m.AwayTeam).WillCascadeOnDelete(false);
            modelBuilder.Entity<Team>().HasMany(t => t.HomeMatches).WithRequired(m => m.HomeTeam).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
