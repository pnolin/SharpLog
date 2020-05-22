using Blazored.LocalStorage;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services
{
    public class SecurityService : ISecurityService
    {
        private const string idTokenStorageKey = "idToken";

        private readonly ISecurityDataService _securityDataService;
        private readonly ILocalStorageService _localStorageService;

        public SecurityService(
            ISecurityDataService securityDataService,
            ILocalStorageService localStorageService
        )
        {
            _securityDataService = securityDataService;
            _localStorageService = localStorageService;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            var idToken = await _localStorageService.GetItemAsync<string>(idTokenStorageKey);

            return idToken != null;
        }

        public async void LoginUser()
        {
            await _securityDataService.LoginUser();
        }
    }
}