using AutoMapper;
using IGDB;
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
        private readonly IGDBApi _igdb;
        private readonly IMapper _mapper;
        private readonly ISettingsService _settingsService;

        public IGDBApiService(
            IMapper mapper,
            ISettingsService settingsService)
        {
            _mapper = mapper;
            _settingsService = settingsService;
            _igdb = IGDBClient.Create(_settingsService.IGDBApiKey);
        }

        public async Task<IEnumerable<IGDBGame>> SearchGames(string searchText)
        {
            var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id,name,platforms,first_release_date; search \"{searchText}\";");

            return _mapper.Map<IEnumerable<IGDBGame>>(games);
        }

        public async Task<IGDBPlatform> GetPlatformDetails(string id)
        {
            var longId = long.Parse(id);
            var platforms = await _igdb.QueryAsync<Platform>(IGDBClient.Endpoints.Platforms, query: $"fields *; where id = {longId};");
            var platform = platforms.First();

            return _mapper.Map<IGDBPlatform>(platform);
        }
    }
}