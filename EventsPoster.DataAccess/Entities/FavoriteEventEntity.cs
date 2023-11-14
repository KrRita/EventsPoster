using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("favorite_events")]
    public class FavoriteEventEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserEntity User { get; set; }
        [Required]
        public int HoldingEventId { get; set; }
        [Required]
        public HoldingEventEntity HoldingEvent { get; set; }

    }
}
