using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.DataAccess;
using EventsPoster.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;


namespace EventsPoster.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "Ирина",
                Surname ="Сидорова",
                Email ="sidorovaira@mail.ru",
                PhoneNumber="89056301254",
                CardNumber = "4512023659854127",
                PasswordHash ="njdnjfk451541",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Name = "Александр",
                Surname ="Васечкин",
                Email ="vasee4kinAlex@mail.ru",
                PhoneNumber="89152656847",
                CardNumber = "7421023655120014",
                PasswordHash ="sksmk1515ss",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll();

            //assert        
            actualUsers.Should().BeEquivalentTo(users);
        }
        [Test]
        public void GetAllEventsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var type_event = new EventType () 
            { 
                Name = "Опера", 
                ExternalId = Guid.NewGuid() 
            };
            context.TypesEvents.Add(type_event);
            context.SaveChanges();

            var events = new EventEntity[]
            {
            new EventEntity()
            {
                TypeEventId=type_event.Id,
                Name="Руслан и Людмила",
                Desctiption="Потрясающая опера, исполняемая артистами Московского Большого театра",
                AgeViewer=6,
                ExternalId = Guid.NewGuid()
            },
            new EventEntity()
            {
                TypeEventId=type_event.Id,
                Name="Кармен",
                Desctiption="Потрясающая опера, исполняемая артистами Московского Большого театра",
                AgeViewer=12,
                ExternalId = Guid.NewGuid()
            },
            };
            context.Events.AddRange(events);
            context.SaveChanges();

            //execute
            var repository = new Repository<EventEntity>(DbContextFactory);
            var actualEvents = repository.GetAll();

            //assert        
            actualEvents.Should().BeEquivalentTo(events, options => options.Excluding(x => x.EventType));
        }
        [Test]
        public void GetAllUsersWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "Ирина",
                Surname ="Сидорова",
                Email ="sidorovaira@mail.ru",
                PhoneNumber="89056301254",
                CardNumber = "4512023659854127",
                PasswordHash ="njdnjfk451541",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Name = "Александр",
                Surname ="Васечкин",
                Email ="vasee4kinAlex@mail.ru",
                PhoneNumber="89152656847",
                CardNumber = "7421023655120014",
                PasswordHash ="sksmk1515ss",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            //execute

            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Name == "Александр").ToArray();

            //assert
            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Name == "Александр"));
        }

        [Test]
        public void SaveNewUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            //execute

            var user = new UserEntity()
            {
                Name = "Маргарита",
                Surname = "Кравцова",
                Email = "kravtsovarita05@mail.ru",
                PhoneNumber = "89401256325",
                CardNumber = "7412548965231014",
                PasswordHash = "lamc545snsjk",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Id)
                                                                       .Excluding(x => x.ModificationTime)
                                                                       .Excluding(x => x.CreationTime)
                                                                       .Excluding(x => x.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var user = new UserEntity()
            {
                Name = "Ольга",
                Surname = "Петрова",
                Email = "petrovaolaaa@mail.ru",
                PhoneNumber = "89632563210",
                CardNumber = "7852111102365984",
                PasswordHash = "pl7412okm",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            user.Name = "Софья";
            user.Surname = "Ракова";
            user.Email = "rackovasofia@mail.ru";
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }

        [Test]
        public void DeleteUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var user = new UserEntity()
            {
                Name = "Маргарита",
                Surname = "Кравцова",
                Email = "kravtsovarita05@mail.ru",
                PhoneNumber = "89401256325",
                CardNumber = "7412548965231014",
                PasswordHash = "lamc545snsjk",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Delete(user);

            //assert
            context.Users.Count().Should().Be(0);
        }
        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "Ирина",
                Surname ="Сидорова",
                Email ="sidorovaira@mail.ru",
                PhoneNumber="89056301254",
                CardNumber = "4512023659854127",
                PasswordHash ="njdnjfk451541",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Name = "Александр",
                Surname ="Васечкин",
                Email ="vasee4kinAlex@mail.ru",
                PhoneNumber="89152656847",
                CardNumber = "7421023655120014",
                PasswordHash ="sksmk1515ss",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[0].Id);

            //assert
            actualUser.Should().BeEquivalentTo(users[0]);
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "Ирина",
                Surname ="Сидорова",
                Email ="sidorovaira@mail.ru",
                PhoneNumber="89056301254",
                CardNumber = "4512023659854127",
                PasswordHash ="njdnjfk451541",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Name = "Александр",
                Surname ="Васечкин",
                Email ="vasee4kinAlex@mail.ru",
                PhoneNumber="89152656847",
                CardNumber = "7421023655120014",
                PasswordHash ="sksmk1515ss",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[users.Length-1].Id+1);

            //assert
            actualUser.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}
