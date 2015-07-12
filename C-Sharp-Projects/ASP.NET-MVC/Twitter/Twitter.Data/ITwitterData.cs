namespace Twitter.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<Message> Messages { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Report> Reports { get; }

        IRepository<IdentityRole> Roles { get; }
        
        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
