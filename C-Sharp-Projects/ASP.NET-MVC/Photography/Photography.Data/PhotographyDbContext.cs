namespace Photography.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Photography.Models;

    public class PhotographyDbContext : IdentityDbContext<User>, IPhotographyDbContext
    {
        public PhotographyDbContext()
            : base("PhotographyConnection", false)
        {
        }

        public IDbSet<Photograph> Photographs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Equipment> Equipment { get; set; }

        public IDbSet<Camera> Cameras { get; set; }

        public IDbSet<Lense> Lenses { get; set; }

        public static PhotographyDbContext Create()
        {
            return new PhotographyDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Lenses)
                .WithRequired(l => l.Manufacturer)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Cameras)
                .WithRequired(l => l.Manufacturer)
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}