using SharpLog.FrontEnd.Models.Enums;
using SharpLog.FrontEnd.Models.Security;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces.DataServices
{
    public interface ISecurityDataService
    {
        Task<AccessTokens> GetAccessTokensAsync(AuthenticationProvider authenticationProvider, string code);
    }
}