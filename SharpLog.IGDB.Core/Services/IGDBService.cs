using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
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

        public Task<IEnumerable<IGDBGame>> SearchGames(string searchText)
            => _igdbApiService.SearchGames(searchText);
    }
}