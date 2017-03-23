using OlimpicsWebApi.Repositories.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OlimpicsWebApi.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhere(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetSingle(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetSingle(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
