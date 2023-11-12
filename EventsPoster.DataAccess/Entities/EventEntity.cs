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
        public int IdTypeEvent { get; set; }
        public TypeEventEntity TypeEvent { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int AgeViewer { get; set; }
        public ICollection<HoldingEventEntity> Holdings { get; set; }
        public ICollection<FeedbackEntity> Feedbacks { get; set; }

    }
}
