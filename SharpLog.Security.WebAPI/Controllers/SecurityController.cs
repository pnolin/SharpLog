using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpLog.Security.Core.Interfaces;
using System.Threading.Tasks;

namespace SharpLog.Security.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(
            ISecurityService securityService,
            IMapper mapper
        )
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("login/")]
        public async Task<IActionResult> Login()
        {
            var loggedInUser = await _securityService.GetLoggedInUser();

            return Ok(loggedInUser);
        }
    }
}