using SharpLog.Core.Interfaces;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Users.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileDataService _userProfileDataService;
        private readonly IIDGeneratorService _idGeneratorService;

        public UserProfileService(
            IUserProfileDataService userProfileDataService,
            IIDGeneratorService idGeneratorService
        )
        {
            _userProfileDataService = userProfileDataService;
            _idGeneratorService = idGeneratorService;
        }

        public async Task<UserProfile> CreateNewProfileAsync(UserProfile userProfile)
        {
            userProfile.Id = _idGeneratorService.GenerateId(userProfile.Id);

            await _userProfileDataService.AddAsync(userProfile);

            return userProfile;
        }
    }
}