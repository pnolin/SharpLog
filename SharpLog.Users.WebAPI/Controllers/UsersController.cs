using Microsoft.AspNetCore.Mvc;
using SharpLog.Framework.WebAPI.Controllers;
using System.Threading.Tasks;

namespace SharpLog.Users.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UsersController : BaseApiController
    {
        [HttpPost]
        [Route("users/")]
        public async Task<IActionResult> CreateUserAsync()
        {
            return NoContent();
        }
    }
}