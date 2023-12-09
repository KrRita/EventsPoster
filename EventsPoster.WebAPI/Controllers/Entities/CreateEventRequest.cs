using System.ComponentModel.DataAnnotations;

namespace EventsPoster.Service.Controllers.Entities
{
    public class CreateEventRequest
    {
        [Required]
        public int IdTypeEvent;
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public string Desctiption { get; set; }
        [Required]
        [Range(0,18)]
        public int AgeViewer { get; set; }
    }
}
