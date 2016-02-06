namespace SportSystem.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public class SportSystemData : ISportSystemData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;
        private IUserStore<User> userStore;

        public SportSystemData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Team> Teams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IRepository<Match> Matches
        {
            get { return this.GetRepository<Match>(); }
        }

        public IRepository<Player> Players
        {
            get { return this.GetRepository<Player>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Bet> Bets
        {
            get { return this.GetRepository<Bet>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IUserStore<User> UserStore
        {
            get { return this.userStore ?? (this.userStore = new UserStore<User>(this.dbContext)); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var repoType = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(repoType, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
