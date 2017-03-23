using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OlimpicsWebApi.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OlimpicsWebApi.Repositories.Core.Context;
using OlimpicsWebApi.Repositories.Core.Entity;

namespace OlimpicsWebApi.Repositories.Core
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
           where T : class, IEntityBase, new()
    {
        private BaseContext context;

        public EntityBaseRepository(BaseContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public virtual Int32 Count()
        {
            return context.Set<T>().Count();
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public T GetSingle(Guid id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, Boolean>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, Boolean>> predicate, params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, Boolean>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, Boolean>> predicate)
        {
            IEnumerable<T> entities = context.Set<T>().Where(predicate);

            foreach (var entity in entities)
                context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }
    }
}
