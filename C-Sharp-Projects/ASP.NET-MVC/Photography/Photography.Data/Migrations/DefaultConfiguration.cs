namespace Photography.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Photography.Models;

    public sealed class DefaultConfiguration : DbMigrationsConfiguration<PhotographyDbContext>
    {
        public DefaultConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhotographyDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            SeedUsers(context);
            SeedAlbums(context);
            SeedManufacturers(context);
            SeedCameras(context);
            SeedLenses(context);
            SeedEquipments(context);
            SeedPhotos(context);
            SeedPhotosInAlbums(context);
        }

        private static void SeedUsers(DbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var nakov = new User { UserName = "nakov", Email = "nakov@softuni.bg" };
            userManager.Create(nakov, "123sl0jna");

            var alex = new User { UserName = "alex", Email = "alex@softuni.bg" };
            userManager.Create(alex, "P@ssW0RD!123");

            var vGeorgiev = new User { UserName = "VGeorgiev", Email = "vlado@softuni.bg" };
            userManager.Create(vGeorgiev, "12qw!@QW");

            context.SaveChanges();
        }

        private static void SeedAlbums(IPhotographyDbContext context)
        {
            var nakov = context.Users.FirstOrDefault(u => u.UserName == "nakov");
            var alex = context.Users.FirstOrDefault(u => u.UserName == "alex");
            var vlado = context.Users.FirstOrDefault(u => u.UserName == "VGeorgiev");

            context.Albums.Add(new Album { Name = "Mobile Photos", Description = "My mobile uploads", User = nakov });

            context.Albums.Add(
                new Album { Name = "SoftUni TeamBuilding", Description = "Special thanks to organizers", User = alex });

            context.Albums.Add(
                new Album
                {
                    Name = "The little things in my life",
                    Description = "Unforgettable moments...",
                    User = alex
                });

            context.Albums.Add(
                new Album { Name = "Open Fest 2014", Description = "OpenFest - Sofia, 1-Nov-2014", User = vlado });

            context.Albums.Add(
                new Album
                {
                    Name = "VarnaConf 2013",
                    Description = "Conference about programming and technologies",
                    User = vlado
                });

            context.Albums.Add(new Album { Name = "SoftUni Conf May 2014", User = nakov });
        }

        private static void SeedManufacturers(IPhotographyDbContext context)
        {
            context.Manufacturers.Add(new Manufacturer { Name = "Pentax" });
            context.Manufacturers.Add(new Manufacturer { Name = "Canon" });
            context.Manufacturers.Add(new Manufacturer { Name = "Nikon" });
            context.Manufacturers.Add(new Manufacturer { Name = "Leica" });
            context.Manufacturers.Add(new Manufacturer { Name = "Sigma" });
            context.Manufacturers.Add(new Manufacturer { Name = "Panasonic" });
            context.Manufacturers.Add(new Manufacturer { Name = "Sony" });

            context.SaveChanges();
        }

        private static void SeedCameras(IPhotographyDbContext context)
        {
            var cameras = new List<Camera>
            {
                new Camera
                {
                    Model = "K-3 II",
                    Year = 2015,
                    Price = 969,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Pentax")
                },
                new Camera
                {
                    Model = "K-S2",
                    Year = 2015,
                    Price = 860,
                    Megapixels = 20,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Pentax")
                },
                new Camera
                {
                    Model = "K-S1",
                    Year = 2015,
                    Price = 360,
                    Megapixels = 20,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Pentax")
                },
                new Camera
                {
                    Model = "Q-S1",
                    Year = 2015,
                    Price = 297,
                    Megapixels = 12,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Pentax")
                },
                new Camera
                {
                    Model = "5DS",
                    Year = 2015,
                    Price = 3899,
                    Megapixels = 51,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Camera
                {
                    Model = "EOS 760D",
                    Year = 2014,
                    Price = 1298,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Camera
                {
                    Model = "EOS 750D",
                    Year = 2013,
                    Price = 749,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Camera
                {
                    Model = "EOS M3",
                    Year = 2013,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Camera
                {
                    Model = "PowerShot SX530 HS",
                    Year = 2015,
                    Price = 249,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Camera
                {
                    Model = "D7200",
                    Year = 2015,
                    Price = 1644,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Camera
                {
                    Model = "D5500",
                    Year = 1194,
                    Megapixels = 22,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Camera
                {
                    Model = "D750",
                    Year = 2013,
                    Price = 3697,
                    Megapixels = 24,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                }
            };

            foreach (var camera in cameras)
            {
                context.Cameras.Add(camera);
            }
        }

        private static void SeedLenses(IPhotographyDbContext context)
        {
            var lenses = new List<Lense>
            {
                new Lense
                {
                    Model = "EF 8-15 f/4L Fisheye USM",
                    Type = "Wideangle fisheye zoom lens",
                    Price = 1249,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Lense
                {
                    Model = "EF 14mm f/2.8L II USM",
                    Type = "Wideangle prime lens",
                    Price = 2099,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Lense
                {
                    Model = "EF 16-35mm f/2.8L II USM",
                    Type = "Wideangle zoom lens",
                    Price = 1599,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Canon")
                },
                new Lense
                {
                    Model = "AF Nikkor 24-85mm f/2.8-4D IF",
                    Type = "Zoom lens",
                    Price = 729,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Lense
                {
                    Model = "AF-S DX Nikkor 35mm f/1.8G",
                    Type = "Prime lens",
                    Price = 197,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Lense
                {
                    Model = "AF-S Micro-Nikkor 60mm f/2.8G ED",
                    Type = "Macro prime lens",
                    Price = 529,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Lense
                {
                    Model = "AF-S DX Nikkor 55-200mm f/4-5.6G VR II",
                    Type = "Telephoto zoom lens",
                    Price = 982,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                },
                new Lense
                {
                    Model = "AF-S Micro-Nikkor 105mm f/2.8G IF-ED VR",
                    Type = "Telephoto macro prime lens",
                    Price = 347,
                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon")
                }
            };

            foreach (var lense in lenses)
            {
                context.Lenses.Add(lense);
            }
        }

        private static void SeedEquipments(IPhotographyDbContext context)
        {
            context.SaveChanges();
            var lenses = context.Lenses.ToList();
            var cameras = context.Cameras.ToList();
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                context.Equipment.Add(
                    new Equipment
                    {
                        Lense = lenses[rand.Next(lenses.Count)],
                        Camera = cameras[rand.Next(cameras.Count)]
                    });
            }
        }

        private static void SeedPhotos(IPhotographyDbContext context)
        {
            context.SaveChanges();
            var nakov = context.Users.FirstOrDefault(u => u.UserName == "nakov");
            var alex = context.Users.FirstOrDefault(u => u.UserName == "alex");
            var vlado = context.Users.FirstOrDefault(u => u.UserName == "VGeorgiev");
            var equipments = context.Equipment.ToList();
            var rand = new Random();

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Dog",
                    Url = "http://dogblogforeveryone.weebly.com/uploads/1/3/7/2/13722182/658040288_orig.jpg",
                    User = nakov,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Clouds",
                    Url = "http://are.berkeley.edu/~jperloff/PHOTO/VIEW/clouds21.jpg",
                    User = nakov,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "They are coming",
                    Url =
                        "http://orig09.deviantart.net/0e12/f/2013/309/d/a/they_are_coming____by_aoki_lifestream-d6t5z1x.jpg",
                    User = alex,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "On the tree",
                    Url =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7tfSasq61h3jjt0epnbjLMHLmn5OzeF19_Z5fP9c6LhxuG2e0",
                    User = nakov,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Witty weather…",
                    Url = "http://cdn.picturecorrect.com/wp-content/uploads/2010/05/bad-weather.jpg",
                    User = alex,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Angel eyes",
                    Url =
                        "http://www.hdwallpapersinn.com/wp-content/uploads/2014/07/baby-girl-blue-eyes-beautiful-images-desktop-hd-wallappers.jpg",
                    User = vlado,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Other",
                    Url =
                        "http://www.whitegadget.com/attachments/pc-wallpapers/142820d1389415052-abstract-wallpapers-images-photos-picture-gallery-abstract-picture.jpg",
                    User = alex,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });

            context.Photographs.Add(
                new Photograph
                {
                    Title = "Dot",
                    Url = "http://www.timtadder.com/media/original/24_CMPRO_SPORTS-23.jpg",
                    User = vlado,
                    Equipment = equipments[rand.Next(equipments.Count)]
                });
        }

        private static void SeedPhotosInAlbums(IPhotographyDbContext context)
        {
            context.SaveChanges();
            var albums = context.Albums.ToList();
            var photographs = context.Photographs.ToList();
            var rand = new Random();
            for (var i = 0; i < 20; i++)
            {
                var photograph = photographs[rand.Next(photographs.Count)];
                var album = albums[rand.Next(albums.Count)];
                album.Photographs.Add(photograph);
            }
        }
    }
}