namespace EventsPoster.Service.Settings
{
    public static class EventsPosterSettingsReader
    {
        public static EventsPosterSettings Read(IConfiguration configuration)
        {
            return new EventsPosterSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                EventsPosterDbContextConnectionString = configuration.GetValue<string>("EventsPosterDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
