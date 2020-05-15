using SharpLog.Security.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Security.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<UserIdentity> GetLoggedInUser();
    }
}