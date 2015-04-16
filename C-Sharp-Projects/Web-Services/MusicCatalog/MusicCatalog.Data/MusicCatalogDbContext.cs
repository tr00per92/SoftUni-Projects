namespace MusicCatalog.Data
{
    using System.Data.Entity;
    using MusicCatalog.Data.Migrations;
    using MusicCatalog.Models;

    public class MusicCatalogDbContext : DbContext
    {
        public MusicCatalogDbContext()
            : base("MusicCatalogConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicCatalogDbContext, Configuration>());
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}