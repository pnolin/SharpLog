using SharpLog.Core.Models;
using System;
using System.Collections.Generic;

namespace SharpLog.IGDB.Core.Models
{
    public class IGDBGame : BaseModel
    {
        public string Name { get; set; } = "";
        public IEnumerable<string> Platforms { get; set; } = new List<string>();
        public DateTimeOffset? FirstReleaseDate { get; set; }
    }
}