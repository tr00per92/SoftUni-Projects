namespace Events.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class DefaultConfiguration : DbMigrationsConfiguration<EventsDbContext>
    {
        public DefaultConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EventsDbContext context)
        {
            CreateAdminUser(context);
            CreateSeveralEvents(context);
        }

        private static void CreateAdminUser(EventsDbContext context)
        {
            if (context.Roles.Any() && context.Users.Any())
            {
                return;
            }

            var adminRole = new IdentityRole("Administrator");
            context.Roles.Add(adminRole);

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var admin = new User { UserName = "admin@admin.com", Email = "admin@admin.com", FullName = "The Admin" };
            manager.Create(admin, "123456");
            manager.AddToRole(admin.Id, adminRole.Name);
        }

        private static void CreateSeveralEvents(EventsDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            context.Events.Add(new Event
            {
                Title = "Party @ SoftUni",
                StartTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30)
            });

            context.Events.Add(new Event
            {
                Title = "Party <Again>",
                StartTime = DateTime.Now.Date.AddDays(7).AddHours(23).AddMinutes(00),
                Comments = new HashSet<Comment>
                {
                    new Comment { Content = "User comment", Author = context.Users.First() }
                }
            });

            //context.Events.Add(new Event
            //{
            //    Title = "Another Party <Later>",
            //    StartTime = DateTime.Now.Date.AddDays(8).AddHours(22).AddMinutes(15)
            //});

            //context.Events.Add(new Event
            //{
            //    Title = "Passed Event <Anonymous>",
            //    StartTime = DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(30),
            //    Duration = TimeSpan.FromHours(1.5),
            //    Comments = new HashSet<Comment>
            //    {
            //        new Comment { Content = "<Anonymous> comment" },
            //        new Comment { Content = "User comment", Author = context.Users.First() },
            //        new Comment { Content = "Another <user> comment", Author = context.Users.First() },
            //        new Comment { Content = "<Anonymous> comment" },
            //        new Comment { Content = "User comment", Author = context.Users.First() },
            //        new Comment { Content = "Another <user> comment", Author = context.Users.First() }
            //    }
            //});

            //context.Events.Add(new Event
            //{
            //    Title = "Passed Event <Again>",
            //    StartTime = DateTime.Now.Date.AddDays(-10).AddHours(18).AddMinutes(00),
            //    Duration = TimeSpan.FromHours(3)
            //});

            //context.Events.Add(new Event
            //{
            //    Title = "Passed Event",
            //    StartTime = DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(0),
            //    Author = context.Users.First(),
            //    Comments = new HashSet<Comment>
            //    {
            //        new Comment { Content = "<Anonymous> comment" }
            //    }
            //});

            //context.Events.Add(new Event
            //{
            //    Title = "ASP.NET MVC Lab",
            //    StartTime = DateTime.Now.Date.AddDays(3).AddHours(11).AddMinutes(30),
            //    Author = context.Users.First(),
            //    Description = "This lab will focus on practical <ASP.NET MVC> Web application development",
            //    Duration = TimeSpan.FromHours(2),
            //    Location = "Software University (Sofia)",
            //    Comments = new HashSet<Comment>
            //    {
            //        new Comment { Content = "<Anonymous> comment" },
            //        new Comment { Content = "User comment", Author = context.Users.First() },
            //        new Comment { Content = "Another <user> comment", Author = context.Users.First() }
            //    }
            //});

            context.SaveChanges();
        }
    }
}