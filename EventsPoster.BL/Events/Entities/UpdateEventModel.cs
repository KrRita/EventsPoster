using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Events.Entities
{
    public class UpdateEventModel
    {
        public int TypeEventId;
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int AgeViewer { get; set; }
    }
}
