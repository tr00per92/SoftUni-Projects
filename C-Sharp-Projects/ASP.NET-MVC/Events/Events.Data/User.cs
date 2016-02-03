namespace Events.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<Event> events;

        public User()
        {
            this.events = new HashSet<Event>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        public string FullName { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}