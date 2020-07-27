using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.IGDB.Core.Services
{
    public class IGDBService : IIGDBService
    {
        private readonly IIGDBApiService _igdbApiService;

        public IGDBService(IIGDBApiService igdbApiService)
        {
            _igdbApiService = igdbApiService;
        }

        public async Task<IEnumerable<IGDBGame>> SearchGames(string searchText)
        {
            var games = await _igdbApiService.SearchGames(searchText);

            games = games.Select(game =>
            {
                game.Platforms = game.Platforms
                    .Select(async platform => await _igdbApiService.GetPlatformDetails(platform.Id))
                    .Select(task => task.Result);

                return game;
            });

            return games;
        }
    }
}