using OlimpicsWebApi.Model.Core;
using System;

namespace OlimpicsWebApi.Model
{
    /// <summary>
    /// Dto okna startowego aplikacji.
    /// </summary>
    public class HomePageDto : BaseDto
    {
        public String Username { get; set; }

        public Int32 Level { get; set; }

        public Int32 CurrentExperiance { get; set; }

        public Int32 ExperianceToNextLevel { get; set; }

        public Int32 Coins { get; set; }

        public Int32 Pils { get; set; }

        public Int32 CurrentStamina { get; set; }

        public Int32 StaminaLimit { get; set; }
    }
}
