using SharpLog.FrontEnd.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces.DataServices
{
    public interface IGameDataService
    {
        Task<IEnumerable<SearchedGame>> SearchGames(string searchText);
    }
}