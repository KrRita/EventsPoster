namespace EventsPoster.Service.Settings
{
    public class EventsPosterSettings
    {
        public Uri ServiceUri { get; set; }
        public string EventsPosterDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
