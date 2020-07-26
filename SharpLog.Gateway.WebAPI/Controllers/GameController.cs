using Microsoft.AspNetCore.Mvc;
using SharpLog.Gateway.WebAPI.Models;
using SharpLog.Gateway.WebAPI.Models.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.Gateway.WebAPI.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : BaseGatewayController
    {
        [HttpGet]
        [Route("games")]
        public async Task<IActionResult> GetGames([FromQuery] string searchText)
        {
            var getGamesResponse = await FowardRequest(HttpContext.Request, Clients.IGDB, $"api/games?title={searchText}");
            var getGamesReponseContent = await getGamesResponse.Content.ReadAsStringAsync();
            var searchResult = DeserializeContent<IEnumerable<SearchedGameViewModel>>(getGamesReponseContent);

            return Ok(searchResult);
        }
    }
}