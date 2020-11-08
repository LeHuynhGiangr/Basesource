using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.EF
{
    public class EFRepository<T, K>:Data.Interfaces.IRepository<T, K> where T: class, Data.Interfaces.IEntity<K>
    {                                                                                                            
        private readonly ProjectDbContext _context;                                                              
                                                                                                                 
        public EFRepository(ProjectDbContext context)                                                            
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public T FindById(K id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> entity = _context.Set<T>();
            //Eagerly loading
            foreach(var navigationProperty in navigationProperties)
            {
                entity=entity.Include(navigationProperty);
            }
            return entity.SingleOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            var l_Records = from record in _context.Set<T>() select record;
            return l_Records;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
/*
 * Entity Framework supports three ways to load related data - eager loading, lazy loading and explicit loading. 
 * The techniques shown in this topic apply equally to models created with Code First and the EF Designer.
 */