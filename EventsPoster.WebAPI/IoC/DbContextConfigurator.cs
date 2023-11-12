using EventsPoster.DataAccess;
using EventsPoster.Service.Settings;
using Microsoft.EntityFrameworkCore;


namespace EventsPoster.Service.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, EventsPosterSettings settings)
        {
            services.AddDbContextFactory<EventsPosterDbContext>(
                options => { options.UseSqlServer(settings.EventsPosterDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<EventsPosterDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate(); 
        }
    }
}
