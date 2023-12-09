using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Admins.Entities
{
    public class CreateAdminModel
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
