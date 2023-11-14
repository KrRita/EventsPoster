using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("events")]
    public class EventEntity : BaseEntity
    {
        [Required]
        public int TypeEventId { get; set; }
        [Required]
        public EventType EventType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desctiption { get; set; }
        [Required]
        public int AgeViewer { get; set; }
        public ICollection<HoldingEventEntity> Holdings { get; set; }
        public ICollection<FeedbackEntity> Feedbacks { get; set; }

    }
}
