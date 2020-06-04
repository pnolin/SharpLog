using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Backlog.Core.Interfaces;
using SharpLog.Backlog.Core.Models.Settings;
using SharpLog.Backlog.Core.Requests;
using SharpLog.Backlog.Core.Services;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.MongoDB.Infrastructure.Repositories;
using System.Reflection;

namespace SharpLog.Backlog.WebAPI.Extensions
{
    public static class DIExtensions
    {
        private static readonly Assembly[] _assembliesToScanForDI = new Assembly[]
        {
            typeof(CreateBacklogRequestHandler).Assembly,
        };

        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new BacklogApplicationSettings();

            Framework.WebAPI.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);

            services.RegisterFrameworkWebAPIServices();

            services.AddScoped<IBacklogService, BacklogService>();
            services.AddScoped<IBacklogDataService, BacklogDataService>();
            services.AddScoped(typeof(IRepository<>), typeof(MongoDBRepository<>));

            services.RegisterAllTypesFromGeneric(typeof(IPingHandler<>), _assembliesToScanForDI, true);
            services.RegisterAllTypesFromGeneric(typeof(IRequestHandler<,>), _assembliesToScanForDI, true);
        }
    }
}