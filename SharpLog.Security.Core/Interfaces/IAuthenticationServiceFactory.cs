using SharpLog.Security.Core.Models.Enums;

namespace SharpLog.Security.Core.Interfaces
{
    public interface IAuthenticationServiceFactory
    {
        IAuthenticationService GetAuthenticationService(AuthenticationProvider authenticationProvider);
    }
}