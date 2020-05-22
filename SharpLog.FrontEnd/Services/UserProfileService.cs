using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Models;
using System;

namespace SharpLog.FrontEnd.Services
{
    public class UserProfileService : IUserProfileService
    {
        private UserProfile? _currentUserProfile = null;

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
    }
}