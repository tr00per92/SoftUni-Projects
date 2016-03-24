namespace Geography.CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<GeographyCodeFirstDb>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(GeographyCodeFirstDb db)
        {
            if (db.Countries.Any() || db.Mountains.Any() || db.Peaks.Any())
            {
                return;
            }

            var bulgaria = new Country { CountryCode = "BG", Name = "Bulgaria" };
            db.Countries.Add(bulgaria);
            db.Countries.Add(new Country { CountryCode = "GE", Name = "Germany" });

            var rila = new Mountain { Name = "Rila", Countries = new[] { bulgaria } };
            db.Mountains.Add(rila);
            var pirin = new Mountain { Name = "Pirin", Countries = new[] { bulgaria } };
            db.Mountains.Add(pirin);
            db.Mountains.Add(new Mountain { Name = "Rhodopes", Countries = new[] { bulgaria } });

            db.Peaks.Add(new Peak { Name = "Musala", Mountain = rila, Elevation = 2925 });
            db.Peaks.Add(new Peak { Name = "Malyovitsa ", Mountain = rila, Elevation = 2729 });
            db.Peaks.Add(new Peak { Name = "Vihren ", Mountain = rila, Elevation = 2914 });
        }
    }
}
