using SharpLog.Core.Models;
using System.Collections.Generic;

namespace SharpLog.Backlog.Core.Models
{
    public class Backlog : BaseModel
    {
        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}