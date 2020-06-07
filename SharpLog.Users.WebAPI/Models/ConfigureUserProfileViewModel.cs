using SharpLog.Framework.WebAPI.Models;

namespace SharpLog.Users.WebAPI.Models
{
    public class ConfigureUserProfileViewModel : BaseViewModel
    {
        public string BacklogId { get; set; } = "";
        public string Username { get; set; } = "";
    }
}