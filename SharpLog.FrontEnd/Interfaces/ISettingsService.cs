using SharpLog.FrontEnd.Models.Settings;

namespace SharpLog.FrontEnd.Interfaces
{
    public interface ISettingsService
    {
        GoogleCredentialsSettings GoogleCredentials { get; }
        string ApiRoot { get; }
    }
}