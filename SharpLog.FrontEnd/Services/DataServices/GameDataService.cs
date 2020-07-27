using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services.DataServices
{
    public class GameDataService : IGameDataService
    {
        private readonly GameClient _chickenCoopClient;

        public GameDataService(GameClient chickenCoopClient)
        {
            _chickenCoopClient = chickenCoopClient;
        }

        public Task<IEnumerable<SearchedGame>?> SearchGames(string searchText)
        {
            var url = $"games?searchText={searchText}";

            return _chickenCoopClient.Get<IEnumerable<SearchedGame>>(url);
        }
    }
}