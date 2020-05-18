using Microsoft.AspNetCore.Components;
using SharpLog.FrontEnd.Extensions;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models.Enums;
using System;
using System.Linq;

namespace SharpLog.FrontEnd.Services
{
    public class SecurityService : ISecurityService
    {
        private const string _providerKey = "provider";
        private const char stateSeparator = ';';
        private readonly ISettingsService _settingsService;
        private readonly ISecurityDataService _securityDataService;
        private readonly NavigationManager _navigationManager;

        public SecurityService(
            ISettingsService settingsService,
            ISecurityDataService securityDataService,
            NavigationManager navigationManager
        )
        {
            _settingsService = settingsService;
            _securityDataService = securityDataService;
            _navigationManager = navigationManager;
        }

        public void RedirectToLogin(AuthenticationProvider authenticationProvider)
        {
            var loginUrl = GetLoginUrl(authenticationProvider);
            _navigationManager.NavigateTo(loginUrl);
        }

        public bool IsFromLogin()
        {
            string? stateString;
            var hasState = _navigationManager.TryGetQueryString("state", out stateString);

            if (!hasState || stateString == null)
            {
                return false;
            }

            var stateDictionary = stateString.ToDictionary(stateSeparator);
            string? providerName;
            var hasProvider = stateDictionary.TryGetValue(_providerKey, out providerName);

            if (!hasProvider || providerName == null)
            {
                return false;
            }

            string? code;
            var provider = (AuthenticationProvider)Enum.Parse(typeof(AuthenticationProvider), providerName);
            var hasCode = _navigationManager.TryGetQueryString(GetCodeAttributeNameFromProvider((AuthenticationProvider)provider), out code);

            return hasCode && code != null;
        }

        public async void FetchAccessToken()
        {
            string? stateString;
            _navigationManager.TryGetQueryString("state", out stateString);

            var stateDictionary = stateString.ToDictionary(stateSeparator);

            string? providerName;
            stateDictionary.TryGetValue(_providerKey, out providerName);

            var provider = (AuthenticationProvider)Enum.Parse(typeof(AuthenticationProvider), providerName);

            string? code;
            _navigationManager.TryGetQueryString(GetCodeAttributeNameFromProvider(provider), out code);

            if (code != null)
            {
                var accessTokens = await _securityDataService.GetAccessTokensAsync(provider, code);

                Console.WriteLine(accessTokens.AccessToken);
            }
        }

        public bool IsUserLoggedIn()
        {
            throw new NotImplementedException();
        }

        private string GetLoginUrl(AuthenticationProvider authenticationProvider) =>
            authenticationProvider switch
            {
                AuthenticationProvider.Google => "https://accounts.google.com/o/oauth2/v2/auth"
                    + $"?client_id={_settingsService.GoogleCredentials.ClientId}&redirect_uri={_settingsService.AuthenticationSettings.RedirectUrl}"
                    + $"&response_type=code&scope=email&access_type=offline&state={_providerKey}={authenticationProvider}&prompt=consent",
                _ => throw new ArgumentException("Invalid enum value", nameof(authenticationProvider)),
            };

        private string GetCodeAttributeNameFromProvider(AuthenticationProvider authenticationProvider) =>
            authenticationProvider switch
            {
                AuthenticationProvider.Google => "code",
                _ => throw new ArgumentException("Invalid enum value", nameof(authenticationProvider)),
            };
    }
}