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
        public int IdUser { get; set; }
        public UserEntity User { get; set; }
        public int IdEvent { get; set; }
        public EventEntity Event { get; set; }
        public string Review { get; set; }
    }
}
