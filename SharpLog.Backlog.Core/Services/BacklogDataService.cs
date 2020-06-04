using SharpLog.Backlog.Core.Interfaces;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Services;

namespace SharpLog.Backlog.Core.Services
{
    public class BacklogDataService :
        BaseDataService<Models.Backlog>,
        IBacklogDataService
    {
        public BacklogDataService(
            IRepository<Models.Backlog> repository
        ) : base(repository)
        {
        }
    }
}