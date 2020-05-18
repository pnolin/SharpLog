namespace SharpLog.FrontEnd.Models.Settings
{
    public class ApplicationSettings
    {
        public GoogleCredentialsSettings GoogleCredentials { get; set; } = new GoogleCredentialsSettings();
        public string ApiRoot { get; set; } = "";
    }
}