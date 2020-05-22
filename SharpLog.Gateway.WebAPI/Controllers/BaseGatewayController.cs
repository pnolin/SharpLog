using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpLog.Gateway.WebAPI.Controllers
{
    public class BaseGatewayController : ControllerBase
    {
        private IHttpClientFactory? _httpClientFactory;
        private const string _jsonContentType = "application/json";

        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected IHttpClientFactory HttpClientFactory => _httpClientFactory ??
            (_httpClientFactory = (IHttpClientFactory)HttpContext.RequestServices.GetService(typeof(IHttpClientFactory)));

        protected async Task<HttpResponseMessage> FowardRequest(HttpRequest request, string clientName, string url)
        {
            var client = HttpClientFactory.CreateClient(clientName);

            var requestContent = "";

            using (var bodyStream = request.Body)
            {
                using (var streamReader = new StreamReader(bodyStream, Encoding.UTF8))
                {
                    requestContent = await streamReader.ReadToEndAsync();
                }
            }

            var newUrl = url;

            foreach (var queryParam in request.Query)
            {
                newUrl = QueryHelpers.AddQueryString(newUrl, queryParam.Key, queryParam.Value);
            }

            using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), newUrl))
            {
                newRequest.Content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);

                foreach (var header in request.Headers)
                {
                    if (newRequest.Headers.Contains(header.Key))
                    {
                        newRequest.Headers.Remove(header.Key);
                    }

                    newRequest.Headers.Add(header.Key, header.Value.ToString());
                }

                var response = await client.SendAsync(newRequest);
                client.Dispose();

                return response;
            }
        }

        protected async Task<HttpResponseMessage> SendRequest(string clientName, HttpMethod method, string url, string data)
        {
            using (var request = new HttpRequestMessage(method, url))
            {
                request.Content = new StringContent(data, Encoding.UTF8, _jsonContentType);

                var client = HttpClientFactory.CreateClient(clientName);

                var response = await client.SendAsync(request);

                client.Dispose();

                return response;
            }
        }

        protected string SerializeObject<T>(T value)
        {
            return JsonSerializer.Serialize<T>(value);
        }

        protected T DeserializeContent<T>(string jsonData)
        {
            return JsonSerializer.Deserialize<T>(jsonData, _serializerOptions);
        }
    }
}