namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestLoader
    {
        IPingExecutor<TResponse> LoadPing<TPingHandler, TResponse>() where TPingHandler : IPingHandler<TResponse>;

        IRequestExecutor<TData, TResponse> LoadRequest<T, TRequestHandler, TData, TResponse>(T data) where TRequestHandler : IRequestHandler<TData, TResponse>;
    }
}