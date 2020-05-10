using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Users.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Requests
{
    public class CreateUserRequestHandler : IRequestHandler<UserProfile, UserProfile>
    {
        public Task<UserProfile> HandleAsync(UserProfile data, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserProfile());
        }
    }
}