using System.ComponentModel.DataAnnotations;

namespace EventsPoster.Service.Controllers.Entities
{
    public class CreateDiscountRequest
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [Range(0.1,1)]
        public double Percent { get; set; }

    }
}
