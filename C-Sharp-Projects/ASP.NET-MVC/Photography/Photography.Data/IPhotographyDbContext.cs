namespace Photography.Data
{
    using System.Data.Entity;

    using Photography.Models;

    public interface IPhotographyDbContext
    {
        IDbSet<Photograph> Photographs { get; }

        IDbSet<Album> Albums { get; }

        IDbSet<Manufacturer> Manufacturers { get; }

        IDbSet<Equipment> Equipment { get; }

        IDbSet<Camera> Cameras { get; }

        IDbSet<Lense> Lenses { get; }

        IDbSet<User> Users { get; }

        int SaveChanges();
    }
}