using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IPingExecutorWithResponseTransformation<TMappedReponse>
    {
        Task<TMappedReponse> InvokeAsync(CancellationToken cancellationToken = default);
    }
}