namespace SharpLog.FrontEnd.Models
{
    public class UserProfile : BaseModel
    {
        public string EmailAddress { get; set; } = "";
        public string Username { get; set; } = "";
        public bool Configured { get; set; } = false;
    }
}