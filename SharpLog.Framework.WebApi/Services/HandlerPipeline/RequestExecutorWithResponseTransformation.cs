using AutoMapper;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class RequestExecutorWithResponseTransformation<T, TData, TResponse, TMappedResponse>
        : RequestExecutor<T, TData, TResponse>,
        IRequestExecutorWithResponseTransformation<TMappedResponse>
    {
        private IMapper _mapper;

        public RequestExecutorWithResponseTransformation(
            IRequestHandler<TData, TResponse> requestHandler,
            T data,
            IMapper mapper
        ) : base(requestHandler, data, mapper)
        {
            _mapper = mapper;
        }

        async Task<TMappedResponse> IRequestExecutorWithResponseTransformation<TMappedResponse>.InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await InvokeAsync(cancellationToken);

            return _mapper.Map<TMappedResponse>(response);
        }
    }
}