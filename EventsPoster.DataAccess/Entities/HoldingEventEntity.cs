using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("holding events")]
    public class HoldingEventEntity : BaseEntity
    {
        public int IdEvent { get; set; }
        public EventEntity Event { get; set; }
        public DateTime DateEvent { get; set; }
        public string Location { get; set; } 
        public ICollection<TicketEntity> Tickets { get; set; }
    }
}
