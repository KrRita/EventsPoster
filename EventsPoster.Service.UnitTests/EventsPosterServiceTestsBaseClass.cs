using EventsPoster.DataAccess;
using EventsPoster.DataAccess.Entities;
using EventsPoster.Service.UnitTests.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using NUnit.Framework;

namespace EventsPoster.Service.UnitTests
{
    public class EventsPosterServiceTestsBaseClass
    {
        public EventsPosterServiceTestsBaseClass()
        {
            var settings = TestSettingsHelper.GetSettings();

            _testServer = new TestWebApplicationFactory(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ =>
                {
                    var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                    httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                        .Returns(TestHttpClient);
                    return httpClientFactoryMock.Object;
                }));
                services.PostConfigureAll<JwtBearerOptions>(options =>
                {
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        $"{settings.IdentityServerUri}/.well-known/openid-configuration",
                        new OpenIdConnectConfigurationRetriever(),
                        new HttpDocumentRetriever(TestHttpClient) //important
                        {
                            RequireHttps = false,
                            SendAdditionalHeaderData = true
                        });
                });
            });
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var discountRepository = scope.ServiceProvider.GetRequiredService<IRepository<DiscountEntity>>();
            var discount = discountRepository.Save(new DiscountEntity()
            {
                Name = "test",
                Percent = 5,
            });
            TestDiscountId = discount.Id;
        }

        public T? GetService<T>()
        {
            return _testServer.Services.GetRequiredService<T>();
        }

        private readonly WebApplicationFactory<Program> _testServer;
        protected int TestDiscountId;
        protected HttpClient TestHttpClient => _testServer.CreateClient();
    }
}
