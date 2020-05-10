using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        public Task<UserProfile> CreateNewProfileAsync(UserProfile userProfile)
        {
            return Task.FromResult(new UserProfile());
        }
    }
}