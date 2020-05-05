using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IPingExecutor<TResponse>
    {
        Task<TResponse> InvokeAsync(CancellationToken cancellationToken = default);

        IPingExecutorWithResponseTransformation<TMappedResponse> WithResponseMappedTo<TMappedResponse>();
    }
}