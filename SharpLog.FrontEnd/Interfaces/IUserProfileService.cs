using SharpLog.FrontEnd.Models;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface IUserProfileService
    {
        UserProfile GetCurrentUserProfile();

        void SetCurrentUserProfile(UserProfile userProfile);

        Task<bool> IsUsernameTaken(string username);
    }
}