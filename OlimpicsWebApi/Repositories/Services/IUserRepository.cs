using OlimpicsWebApi.Repositories.Core;
using OlimpicsWebApi.Repositories.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpicsWebApi.Repositories.Services
{
    interface IUserRepository : IEntityBaseRepository<User>
    {
        User GetUser(Guid id);

        void DeleteUser(Guid id);

        IEnumerable<User> GetAllUsers();

    }
}
