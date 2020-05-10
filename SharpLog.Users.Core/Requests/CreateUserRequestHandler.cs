using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Requests
{
    public class CreateUserRequestHandler : IRequestHandler<UserProfile, UserProfile>
    {
        private readonly IUserProfileService _userProfileService;

        public CreateUserRequestHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public Task<UserProfile> HandleAsync(UserProfile data, CancellationToken cancellationToken) =>
            _userProfileService.CreateNewProfileAsync(data);
    }
}