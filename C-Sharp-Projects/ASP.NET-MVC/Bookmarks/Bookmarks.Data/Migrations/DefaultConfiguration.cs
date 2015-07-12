namespace Bookmarks.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bookmarks.Common;
    using Bookmarks.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class DefaultConfiguration : DbMigrationsConfiguration<BookmarksDbContext>
    {
        public DefaultConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookmarksDbContext context)
        {
            if (context.Users.Any() || context.Bookmarks.Any())
            {
                return;
            }

            var adminRole = new IdentityRole(GlobalConstants.AdminRole);
            context.Roles.Add(adminRole);

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var admin = new User { UserName = "admin@admin.com", Email = "admin@admin.com" };
            userManager.Create(admin, "admin4e");
            userManager.AddToRole(admin.Id, GlobalConstants.AdminRole);

            context.Categories.Add(new Category { Name = "Sports" });
            context.Categories.Add(new Category { Name = "Tasks" });
            context.Categories.Add(new Category { Name = "Homeworks" });
            context.Categories.Add(new Category { Name = "Games" });
        }
    }
}
