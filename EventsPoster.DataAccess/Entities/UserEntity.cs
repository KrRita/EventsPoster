using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsPoster.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string CardNumber {  get; set; }
        [Required]
        public string PasswordHash {  get; set; }
        public ICollection<FavoriteEventEntity> FavoriteEvents { get; set;}
        public ICollection<FeedbackEntity> Feedbacks { get; set;}
        public ICollection<BuyingTicketEntity> BuyingTickets { get; set;}

    }
}
