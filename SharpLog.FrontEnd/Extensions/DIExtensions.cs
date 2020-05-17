using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Services;
using System;
using System.Net.Http;

namespace SharpLog.FrontEnd.Extensions
{
    public static class DIExtensions
    {
        public static void SetupDI(
            this IServiceCollection services,
            WebAssemblyHostBuilder builder)
        {
            services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<ISecurityService, SecurityService>();
        }
    }
}