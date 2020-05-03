using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SharpLog.Security.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class SecurityController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        [Route("login/")]
        public IActionResult Login()
        {
            return NoContent();
        }
    }
}