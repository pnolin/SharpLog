using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Framework.WebAPI.Extensions;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Requests;
using SharpLog.Users.Core.Services;
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
            services.RegisterFrameworkWebAPIServices();

            services.AddScoped<IUserProfileService, UserProfileService>();

            services.RegisterAllTypesFromGeneric(typeof(IRequestHandler<,>), _assembliesToScanForDI, true);
        }
    }
}