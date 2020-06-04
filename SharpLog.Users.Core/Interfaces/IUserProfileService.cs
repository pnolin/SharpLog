using SharpLog.Users.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile> CreateNewProfileAsync(UserProfile userProfile);

        Task<string> GetUsernameByUsername(string username);

        Task<UserProfile> ConfigureUserProfile(UserProfile userProfile);
    }
}