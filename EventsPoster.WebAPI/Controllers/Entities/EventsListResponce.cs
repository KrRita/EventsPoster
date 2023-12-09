using EventsPoster.BL.Events;
using EventsPoster.BL.Events.Entities;

namespace EventsPoster.Service.Controllers.Entities
{
    public class EventsListResponce
    {
        public List<EventModel> Events { get; set; }
    }
}
