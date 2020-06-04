using SharpLog.FrontEnd.Models;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface ISecurityService
    {
        Task<bool> IsUserLoggedIn();

        Task<UserProfile> LoginUser();
    }
}