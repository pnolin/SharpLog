using SharpLog.Core.Models.Settings;

namespace SharpLog.Core.Interfaces
{
    public interface ISettingsService
    {
        GoogleApiCredentialsSettings GoogleApiCrendentials { get; }

        MongoDBSettings MongoDBSettings { get; }
    }
}