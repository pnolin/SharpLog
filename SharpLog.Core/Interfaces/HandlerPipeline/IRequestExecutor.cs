using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestExecutor<in TData, TResponse>
    {
        Task<TResponse> InvokeAsync(CancellationToken cancellationToken = default);

        IRequestExecutorWithDataTransformation<TMappedData, TResponse> WithDataMappedTo<TMappedData>();

        IRequestExecutorWithResponseTransformation<TMappedResponse> WithResponseMappedTo<TMappedResponse>();
    }
}