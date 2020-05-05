namespace SharpLog.Core.Interfaces.HandlerPipeline
{
    public interface IRequestLoader
    {
        IPingExecutor<TResponse> LoadPing<TPingHandler, TResponse>() where TPingHandler : IPingHandler<TResponse>;
    }
}