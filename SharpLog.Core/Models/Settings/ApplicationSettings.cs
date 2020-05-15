namespace SharpLog.Core.Models.Settings
{
    public class ApplicationSettings
    {
        public GoogleApiCredentialsSettings GoogleApiCrendentials { get; set; } = new GoogleApiCredentialsSettings();
        public MongoDBSettings MongoDBSettings { get; set; } = new MongoDBSettings();
    }
}