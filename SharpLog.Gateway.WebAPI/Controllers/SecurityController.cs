using Microsoft.AspNetCore.Mvc;
using SharpLog.Gateway.WebAPI.Models.Constants;

using System.Threading.Tasks;

namespace SharpLog.Gateway.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SecurityController : BaseGatewayController
    {
        [HttpGet]
        [Route("security/login")]
        public async Task<IActionResult> Login()
        {
            var getTokenResponse = await FowardRequest(HttpContext.Request, Clients.Security, "api/login");
            var getTokenResponseContent = await getTokenResponse.Content.ReadAsStringAsync();

            return Ok(DeserializeContent<object>(getTokenResponseContent));
        }
    }
}