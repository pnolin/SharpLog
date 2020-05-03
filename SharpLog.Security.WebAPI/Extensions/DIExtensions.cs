using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Framework.WebApi.Models.Settings;

namespace SharpLog.Security.WebAPI.Extensions
{
    public static class DIExtensions
    {
        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new SecurityApplicationSettings();

            Framework.WebApi.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);
        }
    }
}