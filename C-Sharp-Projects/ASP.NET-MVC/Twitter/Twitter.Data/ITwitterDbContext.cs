namespace Twitter.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Models;

    public interface ITwitterDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Tweet> Tweets { get; }

        IDbSet<Message> Messages { get; }

        IDbSet<Report> Reports { get; }

        IDbSet<Notification> Notifications { get; }

        IDbSet<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}
