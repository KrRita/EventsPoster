using EventsPoster.BL.Admins.Entities;
using EventsPoster.BL.Events.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Events
{
    public interface IEventsProvider
    {
        IEnumerable<EventModel> GetEvents(EventModelFilter modelFilter = null);
        EventModel GetEventInfo(Guid id);
    }
}
