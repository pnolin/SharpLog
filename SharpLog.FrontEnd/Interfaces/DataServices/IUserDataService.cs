using SharpLog.FrontEnd.Models;
using SharpLog.FrontEnd.Models.ViewModels;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces.DataServices
{
    public interface IUserDataService
    {
        Task<UserProfile?> LoginUser();

        Task<GetUsernameViewModel?> GetUsernameByUsername(string username);
    }
}