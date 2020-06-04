using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models;
using SharpLog.FrontEnd.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services
{
    public class UserProfileService : IUserProfileService
    {
        private UserProfile? _currentUserProfile = null;
        private IUserDataService _userDataService;

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

        public async Task ConfigureUserProfile(string username)
        {
            if (_currentUserProfile == null)
            {
                throw new InvalidOperationException("Can't configure the user profile if the current user profile is null.");
            }

            var viewModel = new ConfigureUserProfileViewModel()
            {
                Id = _currentUserProfile.Id,
                Username = username
            };

            var newUserProfile = await _userDataService.ConfigureUserProfile(viewModel);

            if (newUserProfile != null)
            {
                _currentUserProfile = newUserProfile;
            }
            else
            {
                throw new Exception("Something wrong happened when trying to configure the user.");
            }
        }
    }
}