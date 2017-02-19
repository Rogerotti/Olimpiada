using Microsoft.IdentityModel.Tokens;
using System;

namespace OlimpicsWebApi.Model.Core.Authentication
{
    /// <summary>
    /// Opcje dla generatora tokenów.
    /// </summary>
    public class TokenProviderOptions
    {
        public String Path { get; set; } = "/api/token";

        public String Issuer { get; set; }

        public String Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(30);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
