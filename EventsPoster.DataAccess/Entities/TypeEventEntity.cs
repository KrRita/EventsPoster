using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsPoster.DataAccess.Entities
{
    [Table("types events")]
    public class TypeEventEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<EventEntity> Events { get; set; }
    }
}
