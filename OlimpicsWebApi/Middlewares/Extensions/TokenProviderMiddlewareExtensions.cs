using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OlimpicsWebApi.Model.Core.Authentication;
using System;
using System.Text;

namespace OlimpicsWebApi.Middlewares.Extensions
{
    public static class TokenProviderMiddlewareExtensions
    {
        /// <summary>
        /// Dostawca generatora tokenów odpowiedzialnych za komunikację.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTokenProvider(
            this IApplicationBuilder builder)
        {
            //TODO wczytywanie z pliku koniguracyjnego
            var secretKey = "Ol@impic@Rec()rds";
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            // opcje tokena
            // sciezka komunikacyjna /api/token
            // wygasa po 30 minutach.
            var options = new TokenProviderOptions
            {
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)  
            };

            return builder.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
