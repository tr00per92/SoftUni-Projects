namespace Photography.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Album> albums;

        private ICollection<Photograph> photographs;

        public User()
        {
            this.albums = new HashSet<Album>();
            this.photographs = new HashSet<Photograph>();
        }

        public int? EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Photograph> Photographs
        {
            get
            {
                return this.photographs;
            }
            set
            {
                this.photographs = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}