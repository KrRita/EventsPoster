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
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber {  get; set; }
        public string PasswordHash {  get; set; }
        public ICollection<FavoriteEventEntity> FavoriteEvents { get; set;}
        public ICollection<FeedbackEntity> Feedbacks { get; set;}
        public ICollection<BuyingTicketEntity> BuyingTickets { get; set;}

    }
}
