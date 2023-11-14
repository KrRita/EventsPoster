using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("holding_events")]
    public class HoldingEventEntity : BaseEntity
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public EventEntity Event { get; set; }
        [Required]
        public DateTime DateEvent { get; set; }
        [Required]
        public string Location { get; set; } 
        public ICollection<TicketEntity> Tickets { get; set; }
    }
}
