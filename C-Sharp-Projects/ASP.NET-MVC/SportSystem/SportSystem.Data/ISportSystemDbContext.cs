namespace SportSystem.Data
{
    using System.Data.Entity;
    using SportSystem.Models;

    public interface ISportSystemDbContext
    {
        IDbSet<Team> Teams { get; }

        IDbSet<Match> Matches { get; }

        IDbSet<Player> Players { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Bet> Bets { get; }

        IDbSet<Vote> Votes { get; }

        IDbSet<User> Users { get; } 
    }
}
