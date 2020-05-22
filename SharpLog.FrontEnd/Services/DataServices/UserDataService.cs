using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces.DataServices;
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

        public Task LoginUser()
        {
            var url = "login";

            return _securityClient.Get<object>(url);
        }
    }
}