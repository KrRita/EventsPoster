using EventsPoster.BL.Admins;
using EventsPoster.BL.Discounts;
using EventsPoster.BL.Events;
using EventsPoster.DataAccess;
using AutoMapper;
using EventsPoster.BL.Auth;
using EventsPoster.DataAccess.Entities;
using EventsPoster.Service.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EventsPoster.Service.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureService(IServiceCollection services, EventsPosterSettings settings)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAdminsProvider>(x =>
            new AdminsProvider(x.GetRequiredService<IRepository<AdminEntity>>(), x.GetRequiredService<IMapper>()));
            services.AddScoped<IAdminsManager, AdminsManager>();

            services.AddScoped<IDiscountsProvider>(x =>
            new DiscountsProvider(x.GetRequiredService<IRepository<DiscountEntity>>(), x.GetRequiredService<IMapper>()));
            services.AddScoped<IDiscountsManager, DiscountsManager>();

            services.AddScoped<IEventsProvider>(x =>
            new EventsProvider(x.GetRequiredService<IRepository<EventEntity>>(), x.GetRequiredService<IMapper>()));
            services.AddScoped<IEventsManager, EventsManager>();

            services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        }
    }
}
