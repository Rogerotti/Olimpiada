using System;

namespace OlimpicsWebApi.Model.Core
{
    /// <summary>
    /// Bazowa klasa dla dto.
    /// </summary>
    public class BaseDto
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
