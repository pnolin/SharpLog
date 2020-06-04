using Microsoft.AspNetCore.Mvc;
using SharpLog.Core.Exceptions;
using SharpLog.Framework.WebAPI.Controllers;
using SharpLog.Users.Core.Models;
using SharpLog.Users.Core.Requests;
using SharpLog.Users.WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace SharpLog.Users.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UsersController : BaseApiController
    {
        [HttpPost]
        [Route("users/")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserProfileViewModel userProfileViewModel)
        {
            var createdUser = await RequestLoader
                .LoadRequest<CreateUserProfileViewModel, CreateUserRequestHandler, UserProfile, UserProfile>(userProfileViewModel)
                .WithDataMappedTo<UserProfile>()
                .WithResponseMappedTo<UserProfileViewModel>()
                .InvokeAsync();

            return CreatedAtAction(nameof(GetUserByIdAsync), new { userId = createdUser.Id }, createdUser);
        }

        [HttpGet]
        [Route("user/{userId}")]
        [ActionName("GetUserByIdAsync")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("user/{username}/username")]
        public async Task<IActionResult> GetUsernameByUsernameAsync([FromRoute] string username)
        {
            try
            {
                var foundUsername = await RequestLoader
                    .LoadRequest<string, GetUsernameByUsernameRequestHandler, string, string>(username)
                    .WithResponseMappedTo<GetUsernameByUsernameViewModel>()
                    .InvokeAsync();

                return Ok(foundUsername);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("user/{id}/configuration")]
        public async Task<IActionResult> ConfigureUserAsync([FromBody] ConfigureUserProfileViewModel userProfile)
        {
            var user = await RequestLoader
                .LoadRequest<ConfigureUserProfileViewModel, ConfigureUserProfileRequestHandler, UserProfile, UserProfile>(userProfile)
                .WithDataMappedTo<UserProfile>()
                .WithResponseMappedTo<UserProfileViewModel>()
                .InvokeAsync();

            return Ok(user);
        }
    }
}