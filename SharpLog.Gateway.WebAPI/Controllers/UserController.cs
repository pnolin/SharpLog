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
    [Route("api/user")]
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

        [HttpGet]
        [Route("user/{username}/username")]
        public async Task<IActionResult> GetUsernameByUsername([FromRoute] string username)
        {
            var getUsernameResponse = await FowardRequest(HttpContext.Request, Clients.Users, $"api/user/{username}/username");

            if (getUsernameResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            var usernameResponseContent = await getUsernameResponse.Content.ReadAsStringAsync();

            return Ok(DeserializeContent<object>(usernameResponseContent));
        }

        [HttpPut]
        [Route("user/{id}/configuration")]
        public async Task<IActionResult> ConfigureUserAsync([FromRoute] string id)
        {
            var createBacklogUserResponse = await SendRequest(Clients.Backlog, HttpMethod.Post, "api/backlogs", string.Empty);

            if (createBacklogUserResponse.StatusCode == HttpStatusCode.Created)
            {
                var backlogAsString = await createBacklogUserResponse.Content.ReadAsStringAsync();
                var backlogViewModel = DeserializeContent<BacklogViewModel>(backlogAsString);

                var userProfileViewModel = await ReadRequestContentAsAsync<ConfigureUserProfileViewModel>(HttpContext.Request);
                userProfileViewModel.BacklogId = backlogViewModel.Id;

                var configureUserProfileData = SerializeObject(userProfileViewModel);

                var configureUserResponse = await SendRequest(Clients.Users, HttpMethod.Put, $"api/user/{id}/configuration", configureUserProfileData);
                var configureUserResponseContent = await configureUserResponse.Content.ReadAsStringAsync();

                return Ok(DeserializeContent<object>(configureUserResponseContent));
            }

            return StatusCode(500, createBacklogUserResponse.Content);
        }
    }
}