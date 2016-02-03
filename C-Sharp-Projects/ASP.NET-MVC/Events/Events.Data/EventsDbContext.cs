namespace Events.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventsDbContext : IdentityDbContext<User>
    {
        public EventsDbContext()
            : base("EventsConnection", false)
        {
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }
    }
}