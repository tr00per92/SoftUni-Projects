namespace Battleships.Data
{
    using Battleships.Data.Repositories;
    using Battleships.Models;
    
    public interface IBattleshipsData
    {
        IRepository<ApplicationUser> Users { get; }

        GamesRepository Games { get; }

        int SaveChanges();
    }
}
