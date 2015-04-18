namespace News.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class NewsRepository : IRepository<News>
    {
        private readonly DbContext dbContext;

        public NewsRepository(DbContext context = null)
        {
            this.dbContext = context ?? new NewsDbContext();
        }

        public IQueryable<News> All()
        {
            return this.dbContext.Set<News>();
        }

        public News Find(object id)
        {
            return this.dbContext.Set<News>().Find(id);
        }

        public void Add(News entity)
        {
            this.dbContext.Set<News>().Add(entity);
        }

        public void Update(News entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(object id)
        {
            this.ChangeState(this.Find(id), EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        private void ChangeState(News news, EntityState state)
        {
            var entry = this.dbContext.Entry(news);
            if (entry.State == EntityState.Detached)
            {
                this.dbContext.Set<News>().Attach(news);
            }

            entry.State = state;
        }
    }
}
