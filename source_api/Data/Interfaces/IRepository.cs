using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        IQueryable<T> GetAll();

        T FindById(K id);
        T FindById(K id, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> FindByIdAsyn(K id);

        T FindSingle(Expression<Func<T, bool>> predicate);
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] navigationProperties);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
        void Remove(K id);

        void RemoveMultiple(List<T> entities);

        public void SaveChanges();
        public void Dispose();
    }
}
