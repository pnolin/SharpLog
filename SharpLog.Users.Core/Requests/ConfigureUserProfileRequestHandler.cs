using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Requests
{
    public class ConfigureUserProfileRequestHandler : IRequestHandler<UserProfile, UserProfile>
    {
        private IUserProfileService _userProfileService;

        public ConfigureUserProfileRequestHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public Task<UserProfile> HandleAsync(UserProfile data, CancellationToken cancellationToken) =>
            _userProfileService.ConfigureUserProfile(data);
    }
}