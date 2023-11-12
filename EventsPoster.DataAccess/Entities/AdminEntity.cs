using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsPoster.DataAccess.Entities
{
    [Table("admins")]
    public class AdminEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
