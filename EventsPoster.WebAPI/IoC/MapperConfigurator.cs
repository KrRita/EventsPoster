using EventsPoster.BL.Mapper;
using EventsPoster.Service.Mapper;

namespace EventsPoster.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<AdminBLProfile>();
            config.AddProfile<DiscountBLProfile>();
            config.AddProfile<EventBLProfile>();
            config.AddProfile<EventTypeBLProfile>();
            config.AddProfile<AdminsServiceProfile>();
            config.AddProfile<DiscountsServiceProfile>();
            config.AddProfile<EventsServiceProfile>();
        });
    }
}