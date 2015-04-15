namespace Battleships.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}
