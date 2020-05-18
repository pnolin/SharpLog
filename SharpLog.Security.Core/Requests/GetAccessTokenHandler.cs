using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Security.Core.Requests
{
    public class GetAccessTokenHandler : IRequestHandler<FetchAccessTokens, AccessTokens>
    {
        private readonly ISecurityService _securityService;

        public GetAccessTokenHandler(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public Task<AccessTokens> HandleAsync(FetchAccessTokens data, CancellationToken cancellationToken) =>
            _securityService.GetAccessTokenAsync(data);
    }
}