using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlimpicsWebApi.Model;
using System;

namespace OlimpicsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET api/home
        [HttpGet]
        [Authorize]
        public HomePageDto Get()
        {
            return new HomePageDto();
        }

        // GET api/home/id
        [HttpGet("{id}")]
        public HomePageDto Get(Int32 id)
        {
            return CreateHomePageDtoMock(id);
        }

        private HomePageDto CreateHomePageDtoMock(Int32 id)
        {
            if (id == 1)
            {
                return new HomePageDto()
                {
                    Username = "Roger",
                    Level = 5,
                    CurrentExperiance = 200,
                    ExperianceToNextLevel = 500,
                    StaminaLimit = 10,
                    CurrentStamina = 10,
                    Coins = 20,
                    Pils = 0
                };
            }

            return new HomePageDto()
            {
                Username = "Staszek",
                Level = 1,
                CurrentExperiance = 0,
                ExperianceToNextLevel = 10,
                StaminaLimit = 10,
                CurrentStamina = 10,
                Coins = 0,
                Pils = 0
            };


        }
    }

}
