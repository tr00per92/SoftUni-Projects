using Microsoft.AspNet.Identity;
using Twitter.Models;

namespace Twitter.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Common;

    public sealed class DefaultConfiguration : DbMigrationsConfiguration<TwitterDbContext>
    {
        public DefaultConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole(Constants.AdminRoleName));

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var admin = new User { UserName = Constants.AdminUsername, Email = "admin@twitter.com" };
                manager.Create(admin, "admin4e");
                manager.AddToRole(admin.Id, Constants.AdminRoleName);
            }
        }
    }
}
