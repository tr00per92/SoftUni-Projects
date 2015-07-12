namespace Bookmarks.Data
{
    using System.Data.Entity;
    using Bookmarks.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookmarksDbContext : IdentityDbContext<User>, IBookmarksDbContext
    {
        public BookmarksDbContext()
            : base("BookmarksConnection", false)
        {
        }

        public IDbSet<Bookmark> Bookmarks { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Comments).WithRequired(c => c.User).WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>().HasMany(c => c.Bookmarks).WithRequired(b => b.Category).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
