using IGDB.Models;
using SharpLog.Core.Interfaces;
using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGDBClient = IGDB.Client;

namespace SharpLog.IGDB.Infrastructure.Services
{
    public class IGDBApiService : IIGDBApiService
    {
        private readonly ISettingsService _settingsService;

        public IGDBApiService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<IEnumerable<IGDBGame>> SearchGames(string searchText)
        {
            var igdb = IGDBClient.Create(_settingsService.IGDBApiKey);

            var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id,name,platforms; search \"{searchText}\";");

            var mappedGames = games.Select(game =>
            {
                return new IGDBGame()
                {
                    Id = game.Id.HasValue ? game.Id.Value.ToString() : "",
                    Name = game.Name,
                    Platforms = game.Platforms != null ? game.Platforms.Ids.Select(id => id.ToString()) : new List<string>()
                };
            });

            return mappedGames;
        }
    }
}