using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Services;
using SharpLog.FrontEnd.Services.DataServices;
using System;

namespace SharpLog.FrontEnd.Extensions
{
    public static class DIExtensions
    {
        public static void SetupDI(
            this IServiceCollection services,
            WebAssemblyHostBuilder builder)
        {
            var apiRoot = builder.Configuration["SharpLogSettings:ApiRoot"];

            services.AddHttpClient<UserClient>((client) =>
            {
                client.BaseAddress = new Uri($"{apiRoot}/user/");
            });

            services.AddBlazoredLocalStorage();

            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserDataService, UserDataService>();
        }
    }
}