using SharpLog.Core.Models;

namespace SharpLog.Users.Core.Models
{
    public class UserProfile : BaseModel
    {
        public string EmailAddress { get; set; } = "";
        public string Username { get; set; } = "";
        public string BacklogId { get; set; } = "";
        public bool Configured { get; set; } = false;
    }
}