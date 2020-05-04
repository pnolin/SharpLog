using SharpLog.Security.Core.Models;
using System.Security.Claims;

namespace SharpLog.Security.Core.Interfaces
{
    public interface IUserIdentityService
    {
        public UserIdentity GetUserIdentityFromClaims(ClaimsIdentity claims);
    }
}