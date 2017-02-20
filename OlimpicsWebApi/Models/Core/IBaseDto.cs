using System;

namespace OlimpicsWebApi.Models.Core
{
    public interface IBaseDto
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
