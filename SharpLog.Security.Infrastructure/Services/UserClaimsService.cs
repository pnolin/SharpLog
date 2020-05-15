using Microsoft.AspNetCore.Http;
using SharpLog.Security.Core.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace SharpLog.Security.Infrastructure.Services
{
    public class UserClaimsService : IUserClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsIdentity GetUserClaims(string authenticationType) =>
            _httpContextAccessor.HttpContext.User.Identities.First(identity => identity.AuthenticationType == authenticationType);
    }
}