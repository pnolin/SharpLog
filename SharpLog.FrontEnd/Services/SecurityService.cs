using Microsoft.AspNetCore.Components;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Models.Enums;
using System;

namespace SharpLog.FrontEnd.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISettingsService _settingsService;
        private readonly NavigationManager _navigationManager;

        public SecurityService(
            ISettingsService settingsService,
            NavigationManager navigationManager
        )
        {
            _settingsService = settingsService;
            _navigationManager = navigationManager;
        }

        public void RedirectToLogin(AuthenticationProvider authenticationProvider)
        {
            var loginUrl = GetLoginUrl(authenticationProvider);
            _navigationManager.NavigateTo(loginUrl);
        }

        private string GetLoginUrl(AuthenticationProvider authenticationProvider)
        {
            if (authenticationProvider == AuthenticationProvider.Google)
            {
                return "https://accounts.google.com/o/oauth2/v2/auth"
                    + $"?client_id={_settingsService.GoogleCredentials.ClientId}&redirect_uri={_settingsService.AuthenticationSettings.RedirectUrl}"
                    + "&response_type=code&scope=email&access_type=offline";
            }

            throw new ArgumentException("Invalid enum value", nameof(authenticationProvider));
        }
    }
}