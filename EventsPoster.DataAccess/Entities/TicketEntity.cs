using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("tickets")]
    public class TicketEntity : BaseEntity
    {
        [Required]
        public int HoldingEventId { get; set; }
        [Required]
        public HoldingEventEntity HoldingEvent { get; set; }
        public int? DiscountId { get; set; }
        public DiscountEntity? Discount { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
