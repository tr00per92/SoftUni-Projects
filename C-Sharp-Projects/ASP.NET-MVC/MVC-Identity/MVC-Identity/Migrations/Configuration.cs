namespace MVC_Identity_Homework.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_Identity_Homework.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any() && !context.Users.Any())
            {
                var adminRole = new IdentityRole("Administrator");
                context.Roles.Add(adminRole);
                
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var admin = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
                manager.Create(admin, "123456");
                manager.AddToRole(admin.Id, "Administrator");
            }
        }
    }
}
