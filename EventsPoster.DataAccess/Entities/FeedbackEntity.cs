using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("feedbacks")]
    public class FeedbackEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserEntity User { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public EventEntity Event { get; set; }
        [Required]
        public string Review { get; set; }
    }
}
