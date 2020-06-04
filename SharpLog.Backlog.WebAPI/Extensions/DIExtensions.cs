using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Backlog.Core.Models.Settings;
using SharpLog.Core.Interfaces;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.MongoDB.Infrastructure.Repositories;

namespace SharpLog.Backlog.WebAPI.Extensions
{
    public static class DIExtensions
    {
        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new BacklogApplicationSettings();

            Framework.WebAPI.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);

            services.RegisterFrameworkWebAPIServices();

            services.AddScoped(typeof(IRepository<>), typeof(MongoDBRepository<>));
        }
    }
}