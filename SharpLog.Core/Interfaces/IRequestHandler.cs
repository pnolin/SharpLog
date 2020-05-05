using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces
{
    public interface IRequestHandler<in TRequest>
    {
        Task HandleAsync(TRequest request, CancellationToken cancellationToken);
    }

    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}