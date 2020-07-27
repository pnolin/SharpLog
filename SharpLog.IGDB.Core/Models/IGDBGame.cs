using SharpLog.Core.Models;
using System;
using System.Collections.Generic;

namespace SharpLog.IGDB.Core.Models
{
    public class IGDBGame : BaseModel
    {
        public string Name { get; set; } = "";
        public IEnumerable<IGDBPlatform> Platforms { get; set; } = new List<IGDBPlatform>();
        public DateTimeOffset? FirstReleaseDate { get; set; }
    }
}