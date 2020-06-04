using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Users.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Requests
{
    public class GetUsernameByUsernameRequestHandler : IRequestHandler<string, string>
    {
        private IUserProfileService _userProfileService;

        public GetUsernameByUsernameRequestHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public Task<string> HandleAsync(string data, CancellationToken cancellationToken) =>
            _userProfileService.GetUsernameByUsername(data);
    }
}