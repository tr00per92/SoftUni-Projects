namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public interface IBlogSystemData
    {
        IUsersRepository Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
