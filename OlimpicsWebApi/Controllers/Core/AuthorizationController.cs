using Microsoft.AspNetCore.Mvc;
using OlimpicsWebApi.Model.Core.Authentication;

namespace OlimpicsWebApi.Controllers.Core
{
    /// <summary>
    /// Bazowy kontroler wraz z autoryzacją tokena.
    /// </summary>
    [TokenAuthorization]
    public abstract class AuthorizationController : ControllerBase
    {
        public AuthorizationController()
        {

        }
    }
}
