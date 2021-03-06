﻿using SharpLog.IGDB.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpLog.IGDB.Core.Interfaces
{
    public interface IIGDBService
    {
        Task<IEnumerable<IGDBGame>> SearchGames(string searchText);
    }
}