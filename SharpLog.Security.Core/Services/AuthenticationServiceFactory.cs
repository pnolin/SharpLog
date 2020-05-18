using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models.Enums;
using System;

namespace SharpLog.Security.Core.Services
{
    public class AuthenticationServiceFactory : IAuthenticationServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAuthenticationService GetAuthenticationService(AuthenticationProvider authenticationProvider) =>
            authenticationProvider switch
            {
                AuthenticationProvider.Google => (IAuthenticationService)_serviceProvider.GetService(typeof(IGoogleAuthenticationService)),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(authenticationProvider)),
            };
    }
}