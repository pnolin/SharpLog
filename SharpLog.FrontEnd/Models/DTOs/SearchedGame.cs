using System.Collections.Generic;

namespace SharpLog.FrontEnd.Models.DTOs
{
    public class SearchedGame : BaseModel
    {
        public string Name { get; set; } = "";

        public IEnumerable<string> Platforms { get; set; } = new List<string>();

        public int? ReleaseYear { get; set; }
    }
}