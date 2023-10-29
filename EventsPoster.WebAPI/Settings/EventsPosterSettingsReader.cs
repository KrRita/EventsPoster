namespace EventsPoster.WebAPI.Settings
{
    public static class EventsPosterSettingsReader
    {
        public static EventsPosterSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new EventsPosterSettings();
        }
    }
}
