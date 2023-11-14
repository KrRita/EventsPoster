using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("discounts")]
    public class DiscountEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Percent {  get; set; }
        public ICollection<TicketEntity> Tickets { get; set; }
    }
}
