using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Security.Core.Requests
{
    public class GetLoggedInUserHandler : IPingHandler<UserIdentity>
    {
        private readonly ISecurityService _securityService;

        public GetLoggedInUserHandler(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public Task<UserIdentity> HandleAsync(CancellationToken cancellationToken)
            => _securityService.GetLoggedInUser();
    }
}