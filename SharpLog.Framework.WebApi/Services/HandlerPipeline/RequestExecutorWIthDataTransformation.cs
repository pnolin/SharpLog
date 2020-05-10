using AutoMapper;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class RequestExecutorWithDataTransformation<TData, TMappedData, TResponse>
        : RequestExecutor<TMappedData, TMappedData, TResponse>,
        IRequestExecutorWithDataTransformation<TMappedData, TResponse>
    {
        public RequestExecutorWithDataTransformation(
            IRequestHandler<TMappedData, TResponse> requestHandler,
            TData data,
            IMapper mapper
        ) : base(requestHandler, mapper.Map<TMappedData>(data), mapper)
        {
        }

        async Task<TResponse> IRequestExecutorWithDataTransformation<TMappedData, TResponse>.InvokeAsync(CancellationToken cancellationToken) =>
            await InvokeAsync(cancellationToken);
    }
}