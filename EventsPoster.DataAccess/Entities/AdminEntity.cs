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
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
