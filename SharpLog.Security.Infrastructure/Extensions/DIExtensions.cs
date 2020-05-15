using Microsoft.Extensions.DependencyInjection;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Infrastructure.Services;

namespace SharpLog.Security.Infrastructure.Extensions
{
    public static class DIExtensions
    {
        public static void RegisterSecurityInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IUserClaimsService, UserClaimsService>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();
        }
    }
}