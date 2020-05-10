using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestExecutorWithDataTransformation<TMappedData, TResponse>
    {
        Task<TResponse> InvokeAsync(CancellationToken cancellationToken = default);

        IRequestExecutorWithResponseTransformation<TMappedResponse> WithResponseMappedTo<TMappedResponse>();
    }
}