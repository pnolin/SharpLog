using AutoMapper;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class RequestExecutor<T, TData, TResponse> : IRequestExecutor<TData, TResponse>
    {
        private readonly IRequestHandler<TData, TResponse> _requestHandler;
        private readonly T _data;
        private readonly IMapper _mapper;

        public RequestExecutor(
            IRequestHandler<TData, TResponse> requestHandler,
            T data,
            IMapper mapper
        )
        {
            _requestHandler = requestHandler;
            _data = data;
            _mapper = mapper;
        }

        public Task<TResponse> InvokeAsync(CancellationToken cancellationToken = default)
        {
            if (!(_data is TData))
            {
                throw new ArgumentException($"Must map the data to {typeof(TData)} before invoking the handler.");
            }

            cancellationToken = cancellationToken == default
                ? new CancellationToken()
                : cancellationToken;

            return _requestHandler.HandleAsync((TData)(object)_data, cancellationToken);
        }

        public IRequestExecutorWithDataTransformation<TMappedData, TResponse> WithDataMappedTo<TMappedData>() =>
            new RequestExecutorWithDataTransformation<T, TMappedData, TResponse>(
                (IRequestHandler<TMappedData, TResponse>)_requestHandler, _data, _mapper
            );

        public IRequestExecutorWithResponseTransformation<TMappedResponse> WithResponseMappedTo<TMappedResponse>() =>
            new RequestExecutorWithResponseTransformation<T, TData, TResponse, TMappedResponse>(_requestHandler, _data, _mapper);
    }
}