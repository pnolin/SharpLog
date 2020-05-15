using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System;

namespace SharpLog.Framework.WebAPI.Services.HandlerPipeline
{
    public class RequestLoader : IRequestLoader
    {
        public IServiceProvider _serviceProvider;
        public IMapper _mapper;

        public RequestLoader(
            IServiceProvider serviceProvider,
            IMapper mapper
        )
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        public IPingExecutor<TResponse> LoadPing<TPingHandler, TResponse>() where TPingHandler : IPingHandler<TResponse>
        {
            var handler = _serviceProvider.GetService<TPingHandler>();

            return new PingExecutor<TResponse>(handler, _mapper);
        }

        public IRequestExecutor<TData, TResponse> LoadRequest<T, TRequestHandler, TData, TResponse>(T data) where TRequestHandler : IRequestHandler<TData, TResponse>
        {
            var handler = _serviceProvider.GetService<TRequestHandler>();

            return new RequestExecutor<T, TData, TResponse>(handler, data, _mapper);
        }
    }
}