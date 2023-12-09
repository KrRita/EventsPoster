using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Events.Entities
{
    public class EventModelFilter
    {
        public int? IdEventType { get; set; }
        public string? Name { get; set; }
        public string? Desctiption { get; set; }
        public int? AgeViewer { get; set; }
    }
}
