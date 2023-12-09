using System.ComponentModel.DataAnnotations;

namespace EventsPoster.Service.Controllers.Entities
{
    public class CreateAdminRequest
    {
        [Required]
        [MinLength(10)]
        public string Login { get; set; }
        [Required]
        [MinLength(10)]
        public string PasswordHash { get; set; }

    }
}
