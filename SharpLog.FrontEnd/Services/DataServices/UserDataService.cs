using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces.DataServices;
using SharpLog.FrontEnd.Models;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services.DataServices
{
    public class UserDataService : IUserDataService
    {
        private readonly UserClient _securityClient;

        public UserDataService(
            UserClient securityClient
        )
        {
            _securityClient = securityClient;
        }

        public Task<UserProfile?> LoginUser()
        {
            var url = "login";

            return _securityClient.Get<UserProfile>(url);
        }
    }
}