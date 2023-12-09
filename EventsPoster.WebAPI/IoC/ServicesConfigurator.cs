using EventsPoster.BL.Admins;
using EventsPoster.BL.Discounts;
using EventsPoster.BL.Events;
using EventsPoster.DataAccess;

namespace EventsPoster.Service.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAdminsProvider, AdminsProvider>();
            services.AddScoped<IAdminsManager, AdminsManager>();
            services.AddScoped<IDiscountsProvider, DiscountsProvider>();
            services.AddScoped<IDiscountsManager, DiscountsManager>();
            services.AddScoped<IEventsProvider, EventsProvider>();
            services.AddScoped<IEventsManager, EventsManager>();
        }
    }
}
