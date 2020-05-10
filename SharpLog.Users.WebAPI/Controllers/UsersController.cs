﻿using Microsoft.AspNetCore.Mvc;
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
    }
}