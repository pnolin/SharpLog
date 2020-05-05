using AutoMapper;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class PingExecutorWithResponseTransformation<TResponse, TMappedResponse> :
        PingExecutor<TResponse>,
        IPingExecutorWithResponseTransformation<TMappedResponse>
    {
        private readonly IMapper _mapper;

        public PingExecutorWithResponseTransformation(IPingHandler<TResponse> pingHandler, IMapper mapper)
            : base(pingHandler, mapper)
        {
            _mapper = mapper;
        }

        async Task<TMappedResponse> IPingExecutorWithResponseTransformation<TMappedResponse>.InvokeAsync(
            CancellationToken cancellationToken
        )
        {
            var response = await InvokeAsync(cancellationToken);

            return _mapper.Map<TMappedResponse>(response);
        }
    }
}