using SharpLog.Core.Models;

namespace SharpLog.IGDB.Core.Models
{
    public class IGDBPlatform : BaseModel
    {
        public string Name { get; set; } = "";
        public string Abbreviation { get; set; } = "";
    }
}