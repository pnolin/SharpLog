using SharpLog.FrontEnd.Models;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces.DataServices
{
    public interface IUserDataService
    {
        Task<UserProfile?> LoginUser();

        Task<string?> GetUsernameByUsername(string username);
    }
}