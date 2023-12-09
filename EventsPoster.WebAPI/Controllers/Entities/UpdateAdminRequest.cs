using System.ComponentModel.DataAnnotations;

namespace EventsPoster.Service.Controllers.Entities
{
    public class UpdateAdminRequest
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
