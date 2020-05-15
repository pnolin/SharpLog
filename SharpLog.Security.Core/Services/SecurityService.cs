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

        public SecurityService(
            IUserClaimsService userContextService,
            IUserIdentityService userIdentityService
        )
        {
            _userContextService = userContextService;
            _userIdentityService = userIdentityService;
        }

        public Task<UserIdentity> GetLoggedInUser()
        {
            var claims = _userContextService.GetUserClaims(AuthenticationTypes.Google);
            var userIdentity = _userIdentityService.GetUserIdentityFromClaims(claims);

            return Task.FromResult(userIdentity);
        }
    }
}