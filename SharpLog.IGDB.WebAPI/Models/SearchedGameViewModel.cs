using SharpLog.Framework.WebAPI.Models;
using System.Collections.Generic;

namespace SharpLog.IGDB.WebAPI.Models
{
    public class SearchedGameViewModel : BaseViewModel
    {
        public string Name { get; set; } = "";
        public IEnumerable<string> Platforms { get; set; } = new List<string>();
    }
}