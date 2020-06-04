using SharpLog.Backlog.Core.Interfaces;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Backlog.Core.Requests
{
    public class CreateBacklogRequestHandler : IPingHandler<Models.Backlog>
    {
        private readonly IBacklogService _backlogService;

        public CreateBacklogRequestHandler(IBacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        public Task<Models.Backlog> HandleAsync(CancellationToken cancellationToken) =>
            _backlogService.CreateBacklogAsync();
    }
}