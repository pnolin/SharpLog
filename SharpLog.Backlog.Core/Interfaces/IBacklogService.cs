using System.Threading.Tasks;

namespace SharpLog.Backlog.Core.Interfaces
{
    public interface IBacklogService
    {
        Task<Models.Backlog> CreateBacklogAsync();
    }
}