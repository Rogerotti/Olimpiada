using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpicsWebApi.Repositories.Core.Entity
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
