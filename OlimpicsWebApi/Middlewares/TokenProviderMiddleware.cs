using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OlimpicsWebApi.Model.Core.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OlimpicsWebApi.Middlewares
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate next;
        private readonly TokenProviderOptions options;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options)
        {
            this.next = next;
            this.options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/api/tesst", StringComparison.Ordinal))
            {
                var token = context.Request.Headers["token"];
                var test2 = new JwtSecurityTokenHandler().ReadToken(token);

            }
           
            // Sprawdza czy żądana ścieżka pasuje do ścieżki midlleware w tym przypadku  [ścieżka z opcji] + token np. api/token
            if (!context.Request.Path.Equals(options.Path, StringComparison.Ordinal))
                return next(context);

            // Zapytanie musi być typu post z Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request, wrong content type expected: application/x-www-form-urlencoded.");
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Headers["username"];
            var password = context.Request.Headers["password"];

            var identity = await GetIdentity(username, password);
            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var dateTimeOffset = new DateTimeOffset(now);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, unixDateTime.ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(options.Expiration),
                signingCredentials: options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)options.Expiration.TotalSeconds
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, 
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            // DON'T do this in production, obviously!
            if (username == "roger" && password == "123")
            {
                return Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), 
                    new Claim[] { }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
