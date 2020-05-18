using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models.Enums;
using SharpLog.FrontEnd.Models.Security;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services.DataServices
{
    public class SecurityDataService : ISecurityDataService
    {
        private readonly ISettingsService _settingsService;
        private readonly SecurityClient _securityClient;

        public SecurityDataService(
            ISettingsService settingsService,
            SecurityClient securityClient
        )
        {
            _settingsService = settingsService;
            _securityClient = securityClient;
        }

        public Task<AccessTokens> GetAccessTokensAsync(AuthenticationProvider authenticationProvider, string code)
        {
            var url = $"access-token?provider={authenticationProvider}&code={code}&redirectUri={_settingsService.AuthenticationSettings.RedirectUrl}";

            return _securityClient.GetAccessTokensAsync(url);
        }
    }
}