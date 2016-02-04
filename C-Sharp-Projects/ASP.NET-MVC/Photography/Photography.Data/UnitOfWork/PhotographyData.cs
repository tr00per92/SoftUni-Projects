namespace Photography.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Photography.Data.Repositories;
    using Photography.Models;

    public class PhotographyData : IPhotographyData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public PhotographyData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Camera> Cameras
        {
            get
            {
                return this.GetRepository<Camera>();
            }
        }

        public IRepository<Lense> Lenses
        {
            get
            {
                return this.GetRepository<Lense>();
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Photograph> Photographs
        {
            get
            {
                return this.GetRepository<Photograph>();
            }
        }

        public IRepository<Equipment> Equipment
        {
            get
            {
                return this.GetRepository<Equipment>();
            }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IUserStore<User> UserStore
        {
            get
            {
                return this.userStore ?? (this.userStore = new UserStore<User>(this.dbContext));
            }
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