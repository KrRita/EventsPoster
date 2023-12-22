using System.Linq.Expressions;
using EventsPoster.BL.Admins;
using EventsPoster.BL.UnitTests.Mapper;
using EventsPoster.DataAccess;
using EventsPoster.DataAccess.Entities;
using Moq;
using NUnit.Framework;

namespace EventsPoster.BL.UnitTests.Admins
{
    [TestFixture]
    public class AdminProviderTests
    {
        [Test]
        public void testGelAllAdmins()
        {
            Expression expression = null;
            Mock<IRepository<AdminEntity>> adminsRepository = new Mock<IRepository<AdminEntity>>();
            adminsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()))
                .Callback((Expression<Func<AdminEntity, bool>> x) => { expression = x; });
            var adminsProvider = new AdminsProvider(adminsRepository.Object, MapperHelper.Mapper);
            var admins = adminsProvider.GetAdmins();

            adminsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()), Times.Exactly(1));
        }
        [Test]
        public void testGetAdminInfo()
        {

        }
    }
}
