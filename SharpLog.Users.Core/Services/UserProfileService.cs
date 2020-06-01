using SharpLog.Core.Exceptions;
using SharpLog.Core.Interfaces;
using SharpLog.Users.Core.Interfaces;
using SharpLog.Users.Core.Models;
using System.Linq;
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
            var allUsers = _userProfileDataService.FindAll();
            var existingUser = allUsers.FirstOrDefault(user => user.EmailAddress == userProfile.EmailAddress);

            if (existingUser != null)
            {
                return existingUser;
            }

            userProfile.Id = _idGeneratorService.GenerateId(userProfile.Id);

            await _userProfileDataService.AddAsync(userProfile);

            return userProfile;
        }

        public Task<string> GetUsernameByUsername(string username)
        {
            var allUsers = _userProfileDataService.FindAll();
            var user = allUsers.FirstOrDefault(user => user.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                throw new NotFoundException();
            }

            return Task.FromResult(user.Username);
        }
    }
}