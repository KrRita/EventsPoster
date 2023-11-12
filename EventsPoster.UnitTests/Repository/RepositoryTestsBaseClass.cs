using EventsPoster.DataAccess;
using EventsPoster.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsPoster.UnitTests.Repository
{
    public class RepositoryTestsBaseClass
    {
        public RepositoryTestsBaseClass()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Test.json", optional: true)
                .Build();

            Settings = EventsPosterSettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<EventsPosterDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<EventsPosterDbContext>(
                options => { options.UseSqlServer(Settings.EventsPosterDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }

        protected readonly EventsPosterSettings Settings;
        protected readonly IDbContextFactory<EventsPosterDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
    }
}

