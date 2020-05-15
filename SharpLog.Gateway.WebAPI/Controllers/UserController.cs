using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpLog.Framework.WebAPI.Controllers;
using SharpLog.Security.Core.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpLog.Orchestrator.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : BaseApiController
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        [Route("user/login/")]
        public async Task<IActionResult> Login()
        {
            var loginUserResponse = await FowardRequest(HttpContext.Request, "https://localhost:44379/api/login");

            if (Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var loggedInUser = await loginUserResponse.Content.ReadAsStringAsync();
            var userIdentity = JsonSerializer.Deserialize<UserIdentity>(loggedInUser, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            using (var createUserRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44323/api/users"))
            {
                var createUserContentString = $@"{{""EmailAddress"": ""{userIdentity.Email}""}}";
                createUserRequest.Content = new StringContent(createUserContentString, Encoding.UTF8, "application/json");

                var client = _clientFactory.CreateClient();

                var createUserResponse = await client.SendAsync(createUserRequest);
                var createUserResponseContent = await createUserResponse.Content.ReadAsStringAsync();

                return Ok(createUserResponseContent);
            }
        }
    }
}