using Blazored.LocalStorage;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models;
using System;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services
{
    public class SecurityService : ISecurityService
    {
        private const string idTokenStorageKey = "idToken";

        private readonly IUserDataService _securityDataService;
        private readonly IUserProfileService _userProfileService;
        private readonly ILocalStorageService _localStorageService;

        public SecurityService(
            IUserDataService userDataService,
            IUserProfileService userProfileService,
            ILocalStorageService localStorageService
        )
        {
            _securityDataService = userDataService;
            _userProfileService = userProfileService;
            _localStorageService = localStorageService;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            var idToken = await _localStorageService.GetItemAsync<string>(idTokenStorageKey);

            return idToken != null;
        }

        public async Task<UserProfile> LoginUser()
        {
            var userProfile = await _securityDataService.LoginUser();

            if (userProfile != null)
            {
                _userProfileService.SetCurrentUserProfile(userProfile);

                return userProfile;
            }

            throw new Exception("Something wrong happened when trying to login the user.");
        }
    }
}