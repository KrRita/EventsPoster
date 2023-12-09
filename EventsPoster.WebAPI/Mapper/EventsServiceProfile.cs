using AutoMapper;
using EventsPoster.BL.Admins.Entities;
using EventsPoster.BL.Events.Entities;
using EventsPoster.Service.Controllers.Entities;


namespace EventsPoster.Service.Mapper
{
    public class EventsServiceProfile : Profile
    {
        public EventsServiceProfile()
        {
            CreateMap<EventsFilter, EventModelFilter>();
            CreateMap<CreateEventRequest, CreateEventModel>();
            CreateMap<UpdateEventRequest, UpdateEventModel>();
        }

    }
}
