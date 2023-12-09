using EventsPoster.BL.Admins.Entities;
using EventsPoster.BL.Events.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Events
{
    public interface IEventsManager
    {
        EventModel CreateEvent(CreateEventModel model);
        void DeleteEvent(Guid id);
        EventModel UpdateEvent(Guid id, UpdateEventModel model);

    }
}
