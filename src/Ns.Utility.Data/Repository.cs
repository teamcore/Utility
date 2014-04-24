using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;
using Ns.Utility.Framework.Caching;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        #region Private Fields

        private readonly DbContext context;
        private readonly ICacheProvider cacheProvider;
        private readonly CacheItemPolicy policy;

        #endregion

        #region ctor

        public Repository(ICacheProvider cacheProvider, CacheItemPolicy policy)
            : this(new SmartContext(), cacheProvider, policy)
        {

        }

        public Repository(DbContext context, ICacheProvider cacheProvider, CacheItemPolicy policy)
        {
            this.context = context;
            this.policy = policy;
            this.cacheProvider = cacheProvider;
            if (Entities == null)
            {
                Entities = this.context.Set<T>();
            }
        }

        #endregion

        #region IRepository<T,TId> Members

        public IQueryable<T> AsQueryable()
        {
            return Entities;
        }

        public T Get(int id)
        {
            var query = AsQueryable();
            return query.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public IList<T> GetAll()
        {
            var query = AsQueryable().Where(x => x.IsDeleted == false);
            return query.ToList();
        }

        public IList<T> Find(Expression<Func<T, bool>> where)
        {
            var query = AsQueryable();
            return query.Where(where).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> where)
        {
            var query = AsQueryable();
            return query.FirstOrDefault(where);
        }

        public void Add(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public IDbSet<T> Entities { get; private set; }

        #endregion
    }
}