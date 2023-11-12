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
        public int IdHoldingEvent { get; set; }
        public HoldingEventEntity HoldingEvent { get; set; }
        public int IdDiscount { get; set; }//optional
        public DiscountEntity Discount { get; set; }//optional
        public double Price { get; set; }
    }
}
