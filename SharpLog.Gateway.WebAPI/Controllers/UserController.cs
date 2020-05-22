using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpLog.Gateway.WebAPI.Controllers;
using SharpLog.Gateway.WebAPI.Models;
using SharpLog.Gateway.WebAPI.Models.Constants;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharpLog.Orchestrator.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : BaseGatewayController
    {
        [HttpGet]
        [Route("user/login/")]
        public async Task<IActionResult> Login()
        {
            var loginUserResponse = await FowardRequest(HttpContext.Request, Clients.Security, "api/login");

            if (loginUserResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var loggedInUser = await loginUserResponse.Content.ReadAsStringAsync();
            var createUserViewModel = DeserializeContent<CreateUserProfileViewModel>(loggedInUser);

            var createUserData = SerializeObject(createUserViewModel);
            var createUserResponse = await SendRequest(Clients.Users, HttpMethod.Post, "api/users", createUserData);
            var createUserResponseContent = await createUserResponse.Content.ReadAsStringAsync();

            return Created(createUserResponse.Headers.Location, DeserializeContent<object>(createUserResponseContent));
        }
    }
}