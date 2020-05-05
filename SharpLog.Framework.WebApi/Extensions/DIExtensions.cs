using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.Core.Models.Settings;
using SharpLog.Core.Services;
using SharpLog.Framework.WebAPI.Services.HandlerPipeline;
using System;
using System.Linq;
using System.Reflection;

namespace SharpLog.Framework.WebAPI.Extensions
{
    public static class DIExtensions
    {
        public static void RegisterAllTypesFromGeneric(
            this IServiceCollection services,
            Type genericType,
            Assembly[] assemblies,
            bool registerConcreteClass = false
        )
        {
            var typesFromAssemblies = assemblies
                .SelectMany(a => a.DefinedTypes.Where(x =>
                    x.GetInterfaces()
                    .Where(t => t.IsGenericType)
                    .Select(t => t.GetGenericTypeDefinition())
                    .Contains(genericType)
                )
            );

            foreach (var type in typesFromAssemblies)
            {
                if (type.IsGenericType)
                {
                    services.Add(
                        new ServiceDescriptor(
                            genericType,
                            type.GetGenericTypeDefinition(),
                            ServiceLifetime.Transient
                        )
                    );
                }
                else
                {
                    services.Add(
                        new ServiceDescriptor(
                            GetGenericInterfaceToRegister(genericType, type),
                            type,
                            ServiceLifetime.Transient
                        )
                    );
                }

                if (registerConcreteClass)
                {
                    services.Add(new ServiceDescriptor(type, type, ServiceLifetime.Transient));
                }
            }
        }

        public static void RegisterFrameworkWebAPIServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestLoader, RequestLoader>();
        }

        public static ISettingsService ReadApplicationSettings<T>(
            IServiceCollection services,
            IConfiguration configuration,
            T appSettings
        ) where T : ApplicationSettings
        {
            services.Configure<T>(configuration);

            configuration.Bind(appSettings);

            var settingsService = new SettingsService(appSettings);

            services.AddSingleton<ISettingsService>(settingsService);
            services.AddSingleton(appSettings);
            services.AddSingleton<ApplicationSettings>(appSettings);

            return settingsService;
        }

        private static Type GetGenericInterfaceToRegister(Type genericType, TypeInfo type) =>
            type.GetInterfaces()
                .Single(x =>
                    x.IsGenericType &&
                    x.GetGenericTypeDefinition() == genericType
    );
    }
}