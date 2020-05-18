using System.Threading.Tasks;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface ISecurityService
    {
        Task<bool> IsUserLoggedIn();

        void LoginUser();
    }
}