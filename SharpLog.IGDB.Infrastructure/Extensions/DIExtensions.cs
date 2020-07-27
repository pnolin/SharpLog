using Microsoft.Extensions.DependencyInjection;
using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Infrastructure.Services;

namespace SharpLog.IGDB.Infrastructure.Extensions
{
    public static class DIExtensions
    {
        public static void RegisterIGDBInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IIGDBApiService, IGDBApiService>();
        }
    }
}