using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.UnitTests.Mapper;
using EventsPoster.DataAccess.Entities;
using EventsPoster.DataAccess;
using Moq;
using NUnit.Framework;
using EventsPoster.BL.Discounts;

namespace EventsPoster.BL.UnitTests.Discounts
{
    [TestFixture]
    public class DiscountProviderTests
    {
        [Test]
        public void testGelAllDiscounts()
        {
            Expression expression = null;
            Mock<IRepository<DiscountEntity>> discountsRepository = new Mock<IRepository<DiscountEntity>>();
            discountsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<DiscountEntity, bool>>>()))
                .Callback((Expression<Func<DiscountEntity, bool>> x) => { expression = x; });
            var discountsProvider = new DiscountsProvider(discountsRepository.Object, MapperHelper.Mapper);
            var discounts = discountsProvider.GetDiscounts();

            discountsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<DiscountEntity, bool>>>()), Times.Exactly(1));

        }
        [Test]
        public void testGetDiscountInfo()
        {

        }

    }
}
