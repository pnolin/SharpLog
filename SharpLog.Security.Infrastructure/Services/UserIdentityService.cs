using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SharpLog.Security.Infrastructure.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        public UserIdentity GetUserIdentityFromClaims(ClaimsIdentity claims)
        {
            return new UserIdentity()
            {
                FirstName = claims.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.GivenName).Value,
                LastName = claims.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.FamilyName).Value,
                Email = claims.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value,
                Identifier = claims.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value,
            };
        }
    }
}