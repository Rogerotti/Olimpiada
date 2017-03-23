using System;

namespace OlimpicsWebApi.Repositories.Core.Entity
{
    public class User : BaseEntity
    {
        public String Username { get; set; }

        public Int32 Level { get; set; }

        public Int32 Experiance { get; set; }

        public Int32 Coins { get; set; }

        public Int32 Pils { get; set; }

        public Int32 CurrentStamina { get; set; }
            
        public Int32 StaminaLimit { get; set; }
    }
}
