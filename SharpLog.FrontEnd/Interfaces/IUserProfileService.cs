using SharpLog.FrontEnd.Models;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface IUserProfileService
    {
        UserProfile GetCurrentUserProfile();

        void SetCurrentUserProfile(UserProfile userProfile);
    }
}