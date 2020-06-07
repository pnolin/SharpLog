using SharpLog.Framework.WebAPI.Models;
using System.Collections.Generic;

namespace SharpLog.Backlog.WebAPI.Models
{
    public class BacklogViewModel : BaseViewModel
    {
        public IEnumerable<GameViewModel>? Games { get; set; }
    }
}