using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestExecutorWithResponseTransformation<TMappedResponse>
    {
        Task<TMappedResponse> InvokeAsync(CancellationToken cancellationToken = default);
    }
}