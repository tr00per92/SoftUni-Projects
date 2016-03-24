namespace Geography.CodeFirst.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GeographyCodeFirstDb : DbContext
    {
        public GeographyCodeFirstDb()
            : base("GeographyCodeFirstDb")
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Mountain> Mountains { get; set; }

        public DbSet<Peak> Peaks { get; set; }
    }
}