using System.Collections.Generic;

namespace SharpLog.Gateway.WebAPI.Models
{
    public class SearchedGameViewModel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public IEnumerable<string> Platforms { get; set; } = new List<string>();
        public int? ReleaseYear { get; set; }
    }
}