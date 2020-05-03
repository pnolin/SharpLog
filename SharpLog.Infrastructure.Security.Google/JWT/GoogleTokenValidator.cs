using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using SharpLog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SharpLog.Infrastructure.Security.Google.JWT
{
    public class GoogleTokenValidator : ISecurityTokenValidator
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly ISettingsService _settingsService;

        public GoogleTokenValidator(ISettingsService settingsService)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _settingsService = settingsService;
        }

        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; } = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;

        public bool CanReadToken(string securityToken)
        {
            return _tokenHandler.CanReadToken(securityToken);
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            var x = new GoogleJsonWebSignature.ValidationSettings();
            x.Audience = new List<string>() { _settingsService.GoogleApiCrendentials.ClientId };
            var payload = GoogleJsonWebSignature.ValidateAsync(securityToken, x).Result;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, payload.Name),
                    new Claim(ClaimTypes.Name, payload.Name),
                    new Claim(JwtRegisteredClaimNames.FamilyName, payload.FamilyName),
                    new Claim(JwtRegisteredClaimNames.GivenName, payload.GivenName),
                    new Claim(JwtRegisteredClaimNames.Email, payload.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, payload.Subject),
                    new Claim(JwtRegisteredClaimNames.Iss, payload.Issuer),
                };

            try
            {
                var principle = new ClaimsPrincipal(new ClaimsIdentity(claims, "google"));
                return principle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}