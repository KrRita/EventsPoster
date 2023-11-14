using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("buying_tickets")]
    public class BuyingTicketEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserEntity User { get; set; }
        [Required]
        public int TicketId { get; set; }
        [Required]
        public TicketEntity Ticket { get; set; }
        [Required]
        public DateTime DatePurchase { get; set; }
    }
}
