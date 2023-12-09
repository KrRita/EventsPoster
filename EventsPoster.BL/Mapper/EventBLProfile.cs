using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventsPoster.BL.Events;
using EventsPoster.BL.Events.Entities;
using EventsPoster.DataAccess.Entities;

namespace EventsPoster.BL.Mapper
{
    public class EventBLProfile : Profile
    {
        public EventBLProfile()
        {
            CreateMap<EventEntity, EventModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
                .ForMember(x => x.EventType, y => y.MapFrom(src => src.EventType));

            CreateMap<CreateEventModel, EventEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Holdings, y => y.Ignore())
                .ForMember(x => x.Feedbacks, y => y.Ignore())
                .ForMember(x => x.TypeEventId, y => y.MapFrom(src => src.IdTypeEvent));
        }

    }
}
