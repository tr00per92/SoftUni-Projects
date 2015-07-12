﻿namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Bookmark> bookmarks;
        private ICollection<Comment> comments;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Bookmark> Bookmarks
        {
            get { return this.bookmarks; }
            set { this.bookmarks = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
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
