using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace OlimpicsWebApi.Models.Core.Authorization
{
    public class TokenAuthorizationAttribute : Attribute, IAuthorizationFilter
    {

        public TokenAuthorizationAttribute()
        {
         
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("token"))
            {
                var headerToken = context.HttpContext.Request.Headers["token"];
                var token = new JwtSecurityTokenHandler().ReadToken(headerToken);
                var test = token.ValidTo < DateTime.Now;
            }
            else
            {
             context.Result = new StatusCodeResult(401);
            }
        }
    }
}
