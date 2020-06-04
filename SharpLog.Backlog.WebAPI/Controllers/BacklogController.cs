using Microsoft.AspNetCore.Mvc;
using SharpLog.Backlog.Core.Requests;
using SharpLog.Backlog.WebAPI.Models;
using SharpLog.Framework.WebAPI.Controllers;
using System;
using System.Threading.Tasks;

namespace SharpLog.Backlog.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BacklogController : BaseApiController
    {
        [HttpPost]
        [Route("backlogs/")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var createdBacklog = await RequestLoader
                .LoadPing<CreateBacklogRequestHandler, Core.Models.Backlog>()
                .WithResponseMappedTo<BacklogViewModel>()
                .InvokeAsync();

            return CreatedAtAction(nameof(GetBacklogByIdAsync), new { id = createdBacklog.Id }, createdBacklog);
        }

        [HttpGet]
        [Route("backlog/{id}")]
        [ActionName("GetBacklogByIdAsync")]
        public async Task<IActionResult> GetBacklogByIdAsync([FromRoute] string id)
        {
            throw new NotImplementedException();
        }
    }
}