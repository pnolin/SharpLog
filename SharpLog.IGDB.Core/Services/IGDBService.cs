using SharpLog.IGDB.Core.Interfaces;
using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.IGDB.Core.Services
{
    public class IGDBService : IIGDBService
    {
        public Task<IEnumerable<IGDBGame>> SearchGames(string searchText)
        {
            var list = new List<IGDBGame>().AsEnumerable();

            return Task.FromResult(list);
        }
    }
}