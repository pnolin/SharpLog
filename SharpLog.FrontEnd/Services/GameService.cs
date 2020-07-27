using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDataService _chickenCoopDataService;

        public GameService(IGameDataService chickenCoopDataService)
        {
            _chickenCoopDataService = chickenCoopDataService;
        }

        public Task<IEnumerable<SearchedGame>> SearchGame(string searchText) =>
            _chickenCoopDataService.SearchGames(searchText);
    }
}