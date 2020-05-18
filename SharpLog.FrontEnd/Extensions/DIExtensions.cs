using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Services;
using SharpLog.FrontEnd.Services.DataServices;
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
            var apiRoot = builder.Configuration["SharpLogSettings:ApiRoot"];

            services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            services.AddHttpClient<SecurityClient>(client =>
                client.BaseAddress = new Uri($"{apiRoot}/security/"));

            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<ISecurityDataService, SecurityDataService>();
        }
    }
}