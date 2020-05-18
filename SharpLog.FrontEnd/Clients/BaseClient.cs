using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Clients
{
    public abstract class BaseClient : HttpClient
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public BaseClient(
            HttpClient client,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager
        )
        {
            _client = client;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        public async Task<TResponse?> Get<TResponse>(string url) where TResponse : class
        {
            await SetAuthorizationHeader();

            TResponse? response = null;

            try
            {
                response = await _client.GetFromJsonAsync<TResponse>(url);
            }
            catch (HttpRequestException exception)
            {
                RedirectToLoginIfUnauthorized(exception);
            }

            return response;
        }

        private async Task SetAuthorizationHeader()
        {
            var currentIdToken = await _localStorageService.GetItemAsync<string>("idToken");

            if (_client.DefaultRequestHeaders.Authorization == null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentIdToken);
            }
            else
            {
                var currentIdTokenInHeader = _client.DefaultRequestHeaders.Authorization.Parameter;

                if (currentIdTokenInHeader != currentIdToken)
                {
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentIdToken);
                }
            }
        }

        private void RedirectToLoginIfUnauthorized(HttpRequestException exception)
        {
            var exceptionMessage = exception.Message;

            if (exceptionMessage.Contains("Unauthorized"))
            {
                _navigationManager.NavigateTo("/login");
            }
        }
    }
}