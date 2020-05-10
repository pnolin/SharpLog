using SharpLog.Core.Models;

namespace SharpLog.Users.Core.Models
{
    public class UserProfile : BaseModel
    {
        public string EmailAddress { get; set; } = "";
    }
}