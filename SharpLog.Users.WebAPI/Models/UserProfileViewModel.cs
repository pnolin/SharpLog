using SharpLog.Framework.WebAPI.Models;

namespace SharpLog.Users.WebAPI.Models
{
    public class UserProfileViewModel : BaseViewModel
    {
        public string? EmailAddress { get; set; }
        public string? Username { get; set; }
        public bool? Configured { get; set; }
    }
}