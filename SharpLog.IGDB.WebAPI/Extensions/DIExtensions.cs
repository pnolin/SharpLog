using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Requests;
using SharpLog.IGDB.Core.Services;
using SharpLog.IGDB.WebAPI.Models.Settings;
using System.Reflection;

namespace SharpLog.IGDB.WebAPI.Extensions
{
    public static class DIExtensions
    {
        private static readonly Assembly[] _assembliesToScanForDI = new Assembly[]
        {
             typeof(SearchGamesRequestHandler).Assembly,
        };

        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new IGDBApplicationSettings();

            Framework.WebAPI.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);

            services.AddScoped<IIGDBService, IGDBService>();

            services.RegisterAllTypesFromGeneric(typeof(IPingHandler<>), _assembliesToScanForDI, true);
            services.RegisterAllTypesFromGeneric(typeof(IRequestHandler<,>), _assembliesToScanForDI, true);

            services.RegisterFrameworkWebAPIServices();
        }
    }
}