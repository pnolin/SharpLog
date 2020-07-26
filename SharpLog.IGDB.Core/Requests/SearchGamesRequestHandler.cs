using SharpLog.Core.Interfaces.HandlerPipeline;
using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharpLog.IGDB.Core.Requests
{
    public class SearchGamesRequestHandler : IRequestHandler<string, IEnumerable<IGDBGame>>
    {
        private readonly IIGDBService _igdbService;

        public SearchGamesRequestHandler(IIGDBService igdbService)
        {
            _igdbService = igdbService;
        }

        public Task<IEnumerable<IGDBGame>> HandleAsync(string data, CancellationToken cancellationToken) =>
            _igdbService.SearchGames(data);
    }
}