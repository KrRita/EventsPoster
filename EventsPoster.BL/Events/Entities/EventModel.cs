using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Events
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public EventTypes EventType { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int AgeViewer { get; set; }
    }
}
