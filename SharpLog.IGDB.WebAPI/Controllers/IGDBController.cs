using Microsoft.AspNetCore.Mvc;
using SharpLog.Framework.WebAPI.Controllers;
using SharpLog.IGDB.Core.Models;
using SharpLog.IGDB.Core.Requests;
using SharpLog.IGDB.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.IGDB.WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class IGDBController : BaseApiController
    {
        [HttpGet]
        [Route("games")]
        public async Task<IActionResult> SearchGames([FromQuery] string searchText)
        {
            var result = await RequestLoader
                .LoadRequest<string, SearchGamesRequestHandler, string, IEnumerable<IGDBGame>>(searchText)
                .WithResponseMappedTo<IEnumerable<SearchedGameViewModel>>()
                .InvokeAsync();

            return Ok(result);
        }
    }
}