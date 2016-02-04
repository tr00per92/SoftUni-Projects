namespace Photography.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;

    using Photography.Data.Repositories;
    using Photography.Models;

    public interface IPhotographyData
    {
        IRepository<Camera> Cameras { get; }

        IRepository<Lense> Lenses { get; }

        IRepository<Album> Albums { get; }

        IRepository<Photograph> Photographs { get; }

        IRepository<Equipment> Equipment { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<User> Users { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}