using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("buying tickets")]
    public class BuyingTicketEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public UserEntity User { get; set; }
        public int IdTicket { get; set; }
        public TicketEntity Ticket { get; set; }
        public DateTime DatePurchase { get; set; }
    }
}
