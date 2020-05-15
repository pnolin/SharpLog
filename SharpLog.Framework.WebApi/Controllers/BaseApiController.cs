using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpLog.Core.Interfaces.HandlerPipeline;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Framework.WebAPI.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private IRequestLoader? _requestLoader;

        protected IRequestLoader RequestLoader => _requestLoader ??
            (_requestLoader = (IRequestLoader)HttpContext.RequestServices.GetService(typeof(IRequestLoader)));

        protected async Task<HttpResponseMessage> FowardRequest(HttpRequest request, string url)
        {
            var client = new HttpClient();

            var requestContent = "";

            using (var bodyStream = request.Body)
            {
                using (var streamReader = new StreamReader(bodyStream, Encoding.UTF8))
                {
                    requestContent = await streamReader.ReadToEndAsync();
                }
            }

            using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), "https://localhost:44379/api/login"))
            {
                newRequest.Content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);

                foreach (var x in request.Headers)
                {
                    if (newRequest.Headers.Contains(x.Key))
                    {
                        newRequest.Headers.Remove(x.Key);
                    }

                    newRequest.Headers.Add(x.Key, x.Value.ToString());
                }

                var response = await client.SendAsync(newRequest);
                client.Dispose();

                return response;
            }
        }
    }
}