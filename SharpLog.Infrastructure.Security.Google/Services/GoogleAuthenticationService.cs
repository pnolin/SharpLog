using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using SharpLog.Core.Interfaces;
using SharpLog.Security.Core.Interfaces;
using SharpLog.Security.Core.Models;
using System;
using System.Threading.Tasks;

namespace SharpLog.Security.Infrastructure.Google.Services
{
    public class GoogleAuthenticationService : IGoogleAuthenticationService
    {
        private readonly ISettingsService _settingsService;
        private JsonSerializerSettings _jsonSerializerSettings;

        public GoogleAuthenticationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }

        public Task<AccessTokens> GetAccessTokenAsync(FetchAccessTokens accessTokenFetchInformation)
        {
            var client = new RestClient();
            client.UseNewtonsoftJson(_jsonSerializerSettings);

            var request = new RestRequest("https://oauth2.googleapis.com/token");
            var body = new GoogleAccessTokensRequest()
            {
                ClientId = _settingsService.GoogleApiCrendentials.ClientId,
                ClientSecret = _settingsService.GoogleApiCrendentials.ClientSecret,
                Code = accessTokenFetchInformation.Code,
                RedirectUri = accessTokenFetchInformation.RedirectUri
            };

            request.AddJsonBody(body);

            var response = client.Post<GoogleAccessTokensResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error while fetching the access code from google, here's the error message: {response.Content}");
            }

            var accessTokens = new AccessTokens()
            {
                AccessToken = response.Data.AccessToken,
                RefreshToken = response.Data.RefreshToken
            };

            return Task.FromResult(accessTokens);
        }

        private class GoogleAccessTokensRequest
        {
            public string ClientId { get; set; } = "";
            public string ClientSecret { get; set; } = "";
            public string Code { get; set; } = "";
            public string GrantType { get; set; } = "authorization_code";
            public string RedirectUri { get; set; } = "";
        }

        private class GoogleAccessTokensResponse
        {
            public string AccessToken { get; set; } = "";
            public string ExpiresIn { get; set; } = "";
            public string RefreshToken { get; set; } = "";
            public string Scope { get; set; } = "";
            public string TokenType { get; set; } = "";
        }
    }
}