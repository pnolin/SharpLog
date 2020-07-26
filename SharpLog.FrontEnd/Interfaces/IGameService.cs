using SharpLog.FrontEnd.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<SearchedGame>> SearchGame(string searchText);
    }
}