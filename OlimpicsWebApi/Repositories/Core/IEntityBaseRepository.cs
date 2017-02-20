using OlimpicsWebApi.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OlimpicsWebApi.Repositories.Core
{
    public interface IEntityBaseRepository<T> where T : class, IBaseDto, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, Object>>[] includeProperties);

        IEnumerable<T> GetAll();

        Int32 Count();

        T GetSingle(Guid id);

        T GetSingle(Expression<Func<T, Boolean>> predicate);

        T GetSingle(Expression<Func<T, Boolean>> predicate, params Expression<Func<T, Object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, Boolean>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, Boolean>> predicate);

        void Commit();
    }
}
