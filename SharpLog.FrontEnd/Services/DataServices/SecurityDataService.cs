using SharpLog.FrontEnd.Clients;
using SharpLog.FrontEnd.Interfaces.DataServices;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Services.DataServices
{
    public class SecurityDataService : ISecurityDataService
    {
        private readonly SecurityClient _securityClient;

        public SecurityDataService(
            SecurityClient securityClient
        )
        {
            _securityClient = securityClient;
        }

        public Task LoginUser(string accessToken)
        {
            var url = "login";

            return _securityClient.LoginUser(url, accessToken);
        }
    }
}