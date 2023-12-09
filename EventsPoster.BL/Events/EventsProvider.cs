using AutoMapper;
using EventsPoster.BL.Admins.Entities;
using EventsPoster.DataAccess.Entities;
using EventsPoster.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.Events.Entities;

namespace EventsPoster.BL.Events
{
    public class EventsProvider : IEventsProvider
    {
        private readonly IRepository<EventEntity> _eventRepository;
        private readonly IMapper _mapper;

        public EventsProvider(IRepository<EventEntity> eventsRepository, IMapper mapper)
        {
            _eventRepository = eventsRepository;
            _mapper = mapper;
        }

        public IEnumerable<EventModel> GetEvents(EventModelFilter modelFilter = null)
        {
            var eventTypeID = modelFilter.IdEventType;
            var name = modelFilter.Name;
            var age = modelFilter.AgeViewer;
            var description = modelFilter.Desctiption;

            var events = _eventRepository.GetAll(x =>
            (eventTypeID == null || eventTypeID == x.TypeEventId) &&
            (name == null || name == x.Name) &&
            (age == x.AgeViewer) && 
            (description == null || description == x.Desctiption));
    

            return _mapper.Map<IEnumerable<EventModel>>(events);
        }

        public EventModel GetEventInfo(Guid id)
        {
            var event_ = _eventRepository.GetById(id);
            if (event_ is null)
                throw new ArgumentException("Event not found.");
            return _mapper.Map<EventModel>(event_);
        }
    }
}
