namespace Bookmarks.Data
{
    using System.Data.Entity;
    using Bookmarks.Models;

    public interface IBookmarksDbContext
    {
        IDbSet<Bookmark> Bookmarks { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<User> Users { get; }

        int SaveChanges();
    }
}
