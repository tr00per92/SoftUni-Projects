namespace SportSystem.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public interface ISportSystemData
    {
        IRepository<Team> Teams { get; }

        IRepository<Match> Matches { get; }

        IRepository<Player> Players { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Vote> Votes { get; }

        IRepository<User> Users { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
