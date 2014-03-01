using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Aprimo.Utility.Framework.DomainModel;

namespace Aprimo.Utility.Framework.Data.Contract
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> AsQueryable();
        T Get(int id);
        IList<T> GetAll();
        IList<T> Find(Expression<Func<T, bool>> expression);
        T FindOne(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IDbSet<T> Entities { get; }
    }
}
