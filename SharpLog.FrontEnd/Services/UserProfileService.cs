using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models;
using System;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services
{
    public class UserProfileService : IUserProfileService
    {
        private UserProfile? _currentUserProfile = null;
        private IUserDataService _userDataService = null;

        public UserProfileService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public UserProfile GetCurrentUserProfile()
        {
            if (_currentUserProfile != null)
            {
                return _currentUserProfile;
            }

            throw new InvalidOperationException("Current user profile is not defined. Please set it before using this method.");
        }

        public void SetCurrentUserProfile(UserProfile userProfile)
        {
            _currentUserProfile = userProfile;
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var foundUsername = await _userDataService.GetUsernameByUsername(username);

            if (foundUsername == null)
            {
                return false;
            }

            return true;
        }
    }
}