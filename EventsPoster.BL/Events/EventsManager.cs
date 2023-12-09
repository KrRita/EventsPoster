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
    public class EventsManager : IEventsManager
    {
        private readonly IRepository<EventEntity> _eventsRepository;
        private readonly IMapper _mapper;
        public EventsManager(IRepository<EventEntity> eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public EventModel CreateEvent(CreateEventModel model)
        {
            var entity = _mapper.Map<EventEntity>(model);
            _eventsRepository.Save(entity); //id, modification, externalId
            return _mapper.Map<EventModel>(entity);
        }
        public void DeleteEvent(Guid id)
        {
            var entity = _eventsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Event not found");
            _eventsRepository.Delete(entity);
        }
        public EventModel UpdateEvent(Guid id, UpdateEventModel model)
        {
            //validate data
            var entity = _eventsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Event not found");
            entity.TypeEventId = model.TypeEventId;
            entity.Name= model.Name;
            entity.Desctiption= model.Desctiption;
            entity.AgeViewer= model.AgeViewer;
            _eventsRepository.Save(entity);
            return _mapper.Map<EventModel>(entity);
        }

    }
}
