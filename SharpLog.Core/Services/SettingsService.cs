using SharpLog.Core.Interfaces;
using SharpLog.Core.Models.Settings;

namespace SharpLog.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ApplicationSettings applicationSettings;

        public SettingsService(ApplicationSettings appSettings)
        {
            this.applicationSettings = appSettings;
        }

        public GoogleApiCredentialsSettings GoogleApiCrendentials => applicationSettings.GoogleApiCrendentials;

        public MongoDBSettings MongoDBSettings => applicationSettings.MongoDBSettings;

        public string IGDBApiKey => applicationSettings.IGDBApiKey;
    }
}