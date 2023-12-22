
using System.ComponentModel.DataAnnotations;
using System.Net;
using EventsPoster.BL.Auth.Entities;
using EventsPoster.DataAccess;
using EventsPoster.DataAccess.Entities;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;


namespace EventsPoster.Service.UnitTests.Users.Authorization
{
    public class LoginUserTests : EventsPosterServiceTestsBaseClass
    {
        [Test]
        public async Task SuccessFullResult()
        {
            //prepare
            var user = new UserEntity()
            {
                Name ="test",
                Surname = "test",
                Email = "test",
                PhoneNumber = "test",
                CardNumber = "test",
                PasswordHash = "test",
            };
            var password = "Password1@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
            var result = await userManager.CreateAsync(user, password);

            //execute
            var query = $"?email={user.UserName}&password={password}";
            var requestUri =
                EventsPosterApiEndpoints.AuthorizeUserEndpoint + query; 
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

            content.Should().NotBeNull();
            content.AccessToken.Should().NotBeNull();
            content.RefreshToken.Should().NotBeNull();

            //check that access token is valid

            var requestToGetAllTrainers =
                new HttpRequestMessage(HttpMethod.Get, EventsPosterApiEndpoints.GetAllEventsEndpoint);

            var clientWithToken = TestHttpClient;
            client.SetBearerToken(content.AccessToken);
            var getAllUsersResponse = await client.SendAsync(requestToGetAllTrainers);

            getAllUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task BadRequestUserNotFoundResultTest()
        {
            //prepare
            var login = "not_existing@mail.ru";
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
            var user = userRepository.GetAll().FirstOrDefault(x => x.UserName.ToLower() == login.ToLower());
            if (user != null)
            {
                userRepository.Delete(user);
            }

            var password = "password";
            //execute
            var query = $"?email={login}&password={password}";
            var requestUri =
                EventsPosterApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task PasswordIsIncorrectResultTest()
        {
            //prepare
            var user = new UserEntity()
            {
                Email = "test@test",
                UserName = "test@test",
            };
            var password = "password";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<UserEntity>>();
            await userManager.CreateAsync(user, password);

            var incorrect_password = "kvhdbkvhbk";

            //execute
            var query = $"?email={user.UserName}&password={incorrect_password}";
            var requestUri =
                EventsPosterApiEndpoints.AuthorizeUserEndpoint + query; 
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }

        [Test]
        [TestCase("", "")]
        [TestCase("qwe", "")]
        [TestCase("test@test", "")]
        [TestCase("", "password")]
        public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
        {
            //execute
            var query = $"?login={login}&password={password}";
            var requestUri =
                EventsPosterApiEndpoints.AuthorizeUserEndpoint + query; 
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }

    }
}
