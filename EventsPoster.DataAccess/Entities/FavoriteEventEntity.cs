using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("favorite events")]
    public class FavoriteEventEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public UserEntity User { get; set; }
        public int IdHoldingEvent { get; set; }
        public HoldingEventEntity HoldingEvent { get; set; }

    }
}
