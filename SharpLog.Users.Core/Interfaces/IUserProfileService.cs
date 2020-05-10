using SharpLog.Users.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile> CreateNewProfileAsync(UserProfile userProfile);
    }
}