using SharpLog.FrontEnd.Models.Security;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Clients
{
    public class SecurityClient
    {
        private readonly HttpClient _client;

        public SecurityClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<AccessTokens> GetAccessTokensAsync(string url)
        {
            AccessTokens accessTokens = await _client.GetFromJsonAsync<AccessTokens>(url);

            return accessTokens;
        }
    }
}