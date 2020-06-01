using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services.DataServices
{
    public class UserDataService : IUserDataService
    {
        private readonly UserClient _userClient;

        public UserDataService(
            UserClient userClient
        )
        {
            _userClient = userClient;
        }

        public Task<UserProfile?> LoginUser()
        {
            var url = "login";

            return _userClient.Get<UserProfile>(url);
        }

        public Task<string?> GetUsernameByUsername(string username)
        {
            var url = $"{username}/username";

            return _userClient.Get<string>(url);
        }
    }
}