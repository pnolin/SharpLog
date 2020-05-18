using System.Net.Http;
using System.Net.Http.Headers;
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

        public Task LoginUser(string url, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return _client.GetFromJsonAsync<object>(url);
        }
    }
}