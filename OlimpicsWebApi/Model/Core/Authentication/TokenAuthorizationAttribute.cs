using Microsoft.AspNetCore.Authorization;

namespace OlimpicsWebApi.Model.Core.Authentication
{
    public class TokenAuthorizationAttribute : AuthorizeAttribute
    {

        public TokenAuthorizationAttribute()
        {
         
        }
    }
}
