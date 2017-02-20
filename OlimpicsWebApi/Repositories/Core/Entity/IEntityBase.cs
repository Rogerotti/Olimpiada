using System;

namespace OlimpicsWebApi.Repositories.Core.Entity
{
    public interface IEntityBase
    {
        /// <summary>
        /// Id elementu.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Nazwa elementu.
        /// </summary>
        String Name { get; set; }
    }
}
