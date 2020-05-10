using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.MongoDB.Infrastructure.Repositories;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Requests;
using SharpLog.Users.Core.Services;
using SharpLog.Users.WebAPI.Models.Settings;
using System.Reflection;

namespace SharpLog.Users.WebAPI.Extensions
{
    public static class DIExtensions
    {
        private static readonly Assembly[] _assembliesToScanForDI = new Assembly[]
        {
            typeof(CreateUserRequestHandler).Assembly,
        };

        public static void SetupDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = new UsersApplicationSettings();

            Framework.WebAPI.Extensions.DIExtensions.ReadApplicationSettings(services, configuration, applicationSettings);

            services.RegisterFrameworkWebAPIServices();

            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUserProfileDataService, UserProfileDataService>();
            services.AddScoped(typeof(IRepository<>), typeof(MongoDBRepository<>));

            services.RegisterAllTypesFromGeneric(typeof(IRequestHandler<,>), _assembliesToScanForDI, true);
        }
    }
}