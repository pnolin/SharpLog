using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Framework.WebApi.Models.Settings;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Services;
using SharpLog.Security.Infrastructure.Extensions;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISecurityService, SecurityService>();

            services.RegisterSecurityInfrastructureService();
        }
    }
}