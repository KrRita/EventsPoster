using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.Events;
using EventsPoster.BL.UnitTests.Mapper;
using EventsPoster.DataAccess.Entities;
using EventsPoster.DataAccess;
using Moq;
using NUnit.Framework;

namespace EventsPoster.BL.UnitTests.Events
{
    [TestFixture]
    public class EventProviderTests
    {
        [Test]
        public void testGelAllEvents()
        {
            Expression expression = null;
            Mock<IRepository<EventEntity>> eventsRepository = new Mock<IRepository<EventEntity>>();
            eventsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<EventEntity, bool>>>()))
                .Callback((Expression<Func<EventEntity, bool>> x) => { expression = x; });
            var eventsProvider = new EventsProvider(eventsRepository.Object, MapperHelper.Mapper);
            var events = eventsProvider.GetEvents();

            eventsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<EventEntity, bool>>>()), Times.Exactly(1));

        }
        [Test]
        public void testGetEventInfo()
        {

        }

    }
}
