using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models;
using SharpLog.Security.Core.Models.Constants;
using System.Threading.Tasks;

namespace SharpLog.Security.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserClaimsService _userContextService;
        private readonly IUserIdentityService _userIdentityService;
        private readonly IAuthenticationServiceFactory _authenticationServiceFactory;

        public SecurityService(
            IUserClaimsService userContextService,
            IUserIdentityService userIdentityService,
            IAuthenticationServiceFactory authenticationServiceFactory
        )
        {
            _userContextService = userContextService;
            _userIdentityService = userIdentityService;
            _authenticationServiceFactory = authenticationServiceFactory;
        }

        public Task<AccessTokens> GetAccessTokenAsync(FetchAccessTokens fetchInformation)
        {
            var securityService = _authenticationServiceFactory.GetAuthenticationService(fetchInformation.Provider);

            return securityService.GetAccessTokenAsync(fetchInformation);
        }

        public Task<UserIdentity> GetLoggedInUser()
        {
            var claims = _userContextService.GetUserClaims(AuthenticationTypes.Google);
            var userIdentity = _userIdentityService.GetUserIdentityFromClaims(claims);

            return Task.FromResult(userIdentity);
        }
    }
}