using SharpLog.Core.Interfaces;
using SharpLog.Core.Services;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;

namespace SharpLog.Users.Core.Services
{
    public class UserProfileDataService
        : BaseDataService<UserProfile>,
        IUserProfileDataService
    {
        public UserProfileDataService(
            IRepository<UserProfile> repository
        ) : base(repository)
        {
        }
    }
}