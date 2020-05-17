using SharpLog.FrontEnd.Models.Enums;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface ISecurityService
    {
        void RedirectToLogin(AuthenticationProvider provider);
    }
}