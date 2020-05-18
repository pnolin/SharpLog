using Microsoft.Extensions.Configuration;
using SharpLog.FrontEnd.Interfaces;
using SharpLog.FrontEnd.Models.Settings;

namespace SharpLog.FrontEnd.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ApplicationSettings _applicationSettings;

        public SettingsService(IConfiguration configuration)
        {
            _applicationSettings = new ApplicationSettings();
            configuration.Bind("SharpLogSettings", _applicationSettings);
        }

        public GoogleCredentialsSettings GoogleCredentials => _applicationSettings.GoogleCredentials;

        public string ApiRoot => _applicationSettings.ApiRoot;
    }
}