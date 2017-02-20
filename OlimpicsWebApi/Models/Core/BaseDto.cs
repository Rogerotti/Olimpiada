using System;

namespace OlimpicsWebApi.Models.Core
{
    /// <summary>
    /// Bazowa klasa dla dto.
    /// </summary>
    public class BaseDto : IBaseDto
    {
        /// <summary>
        /// Id elementu.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nazwa elementu.
        /// </summary>
        public String Name { get; set; }
    }
}
