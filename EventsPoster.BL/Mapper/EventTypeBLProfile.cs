using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventsPoster.BL.Events;
using EventsPoster.DataAccess.Entities;

namespace EventsPoster.BL.Mapper
{
    public class EventTypeBLProfile : Profile
    {
        public static EventTypes TransformEventTypeToEnum (EventType eventType)
        {
            switch (eventType.Name)
            {
                case "Concert":
                    return EventTypes.Concert;
                case "Cinema":
                    return EventTypes.Cinema;
                case "Opera":
                    return EventTypes.Opera;
                case "Ballet":
                    return EventTypes.Ballet;
                case "Performance":
                    return EventTypes.Performance;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), "Non-existent type of event:" + eventType.Name);
            }
        }
        public EventTypeBLProfile()
        {
            CreateMap<EventType, EventTypes>().ConvertUsing((eventType, _, _) => TransformEventTypeToEnum(eventType));
        }
    }
}
