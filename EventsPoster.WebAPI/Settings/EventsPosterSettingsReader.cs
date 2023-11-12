namespace EventsPoster.Service.Settings
{
    public static class EventsPosterSettingsReader
    {
        public static EventsPosterSettings Read(IConfiguration configuration)
        {
            return new EventsPosterSettings()
            {
                EventsPosterDbContextConnectionString = configuration.GetValue<string>("EventsPosterDbContext")
            };
        }
    }
}
