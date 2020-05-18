using SharpLog.Security.Core.Models.Enums;

namespace SharpLog.Security.Core.Models
{
    public class FetchAccessTokens
    {
        public AuthenticationProvider Provider { get; set; }
        public string Code { get; set; } = "";
        public string RedirectUri { get; set; } = "";
    }
}