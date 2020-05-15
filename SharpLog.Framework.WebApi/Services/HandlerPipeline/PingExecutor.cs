using AutoMapper;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class PingExecutor<TResponse> : IPingExecutor<TResponse>
    {
        private readonly IPingHandler<TResponse> _pingHandler;
        private readonly IMapper _mapper;

        public PingExecutor(
            IPingHandler<TResponse> pingHandler,
            IMapper mapper
        )
        {
            _pingHandler = pingHandler;
            _mapper = mapper;
        }

        public Task<TResponse> InvokeAsync(
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken = cancellationToken == default
                ? new CancellationToken()
                : cancellationToken;

            return _pingHandler.HandleAsync(cancellationToken);
        }

        public IPingExecutorWithResponseTransformation<TMappedResponse> WithResponseMappedTo<TMappedResponse>() =>
            new PingExecutorWithResponseTransformation<TResponse, TMappedResponse>(_pingHandler, _mapper);
    }
}