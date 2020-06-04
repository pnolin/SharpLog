using SharpLog.Security.Core.Models.Enums;

namespace SharpLog.Security.WebAPI.Models
{
    public class GetAccessCodeViewModel
    {
        public AuthenticationProvider Provider { get; set; }
        public string? Code { get; set; }
        public string? RedirectUri { get; set; }
    }
}