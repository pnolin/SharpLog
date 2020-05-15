using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IPingHandler<TResponse>
    {
        Task<TResponse> HandleAsync(CancellationToken cancellationToken);
    }
}