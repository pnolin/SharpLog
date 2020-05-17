namespace SharpLog.FrontEnd.Models.Settings
{
    public class ApplicationSettings
    {
        public GoogleCredentialsSettings GoogleCredentials { get; set; } = new GoogleCredentialsSettings();
        public AuthenticationSettings AuthenticationSettings { get; set; } = new AuthenticationSettings();
    }
}