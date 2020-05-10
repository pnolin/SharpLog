using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestHandler<TData, TResponse>
    {
        Task<TResponse> HandleAsync(TData data, CancellationToken cancellationToken);
    }
}