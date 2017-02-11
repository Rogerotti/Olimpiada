using Microsoft.IdentityModel.Tokens;
using System;

namespace OlimpicsWebApi.Model.Core.Authentication
{
    public class TokenProviderOptions
    {
        public String Path { get; set; } = "/token";

        public String Issuer { get; set; }

        public String Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
