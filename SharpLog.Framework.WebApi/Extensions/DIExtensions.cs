using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Models.Settings;
using SharpLog.Core.Services;

namespace SharpLog.Framework.WebAPI.Extensions
{
    public static class DIExtensions
    {
        public static ISettingsService ReadApplicationSettings<T>(
            IServiceCollection services,
            IConfiguration configuration,
            T appSettings
        ) where T : ApplicationSettings
        {
            services.Configure<T>(configuration);

            configuration.Bind(appSettings);

            var settingsService = new SettingsService(appSettings);

            services.AddSingleton<ISettingsService>(settingsService);
            services.AddSingleton(appSettings);
            services.AddSingleton<ApplicationSettings>(appSettings);

            return settingsService;
        }
    }
}