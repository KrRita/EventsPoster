using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventsPoster.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } //ключ в бд
        public Guid ExternalId { get; set; } // unique index - unique optional
        public DateTime ModificationTime { get; set; } 
        public DateTime CreationTime { get; set; } 
    }
}
