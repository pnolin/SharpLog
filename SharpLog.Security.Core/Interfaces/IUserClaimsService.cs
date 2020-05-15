using System.Security.Claims;

namespace SharpLog.Security.Core.Interfaces
{
    public interface IUserClaimsService
    {
        ClaimsIdentity GetUserClaims(string authenticationType);
    }
}