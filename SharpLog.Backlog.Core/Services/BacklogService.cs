using SharpLog.Backlog.Core.Interfaces;
using SharpLog.Core.Interfaces;
using System.Threading.Tasks;

namespace SharpLog.Backlog.Core.Services
{
    public class BacklogService : IBacklogService
    {
        private readonly IBacklogDataService _backlogDataService;
        private readonly IIDGeneratorService _idGeneratorService;

        public BacklogService(
            IBacklogDataService backlogDataService,
            IIDGeneratorService idGeneratorService)
        {
            _backlogDataService = backlogDataService;
            _idGeneratorService = idGeneratorService;
        }

        public async Task<Models.Backlog> CreateBacklogAsync()
        {
            var backlog = new Models.Backlog();
            backlog.Id = _idGeneratorService.GenerateId(null);

            await _backlogDataService.AddAsync(backlog);

            return backlog;
        }
    }
}