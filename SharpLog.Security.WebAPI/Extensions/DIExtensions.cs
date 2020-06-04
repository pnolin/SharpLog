using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.Framework.WebAPI.Models.Settings;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Requests;
using SharpLog.Security.Core.Services;
using SharpLog.Security.Infrastructure.Extensions;
using System.Reflection;

namespace SharpLog.Security.WebAPI.Extensions
{
    public static class DIExtensions
    {
        private static readonly Assembly[] _assembliesToScanForDI = new Assembly[]
        {
            typeof(GetLoggedInUserHandler).Assembly,
        };

        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new SecurityApplicationSettings();

            Framework.WebAPI.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);

            services.RegisterFrameworkWebAPIServices();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISecurityService, SecurityService>();

            services.RegisterAllTypesFromGeneric(typeof(IPingHandler<>), _assembliesToScanForDI, true);
            services.RegisterAllTypesFromGeneric(typeof(IRequestHandler<,>), _assembliesToScanForDI, true);

            services.RegisterSecurityInfrastructureService();
        }
    }
}