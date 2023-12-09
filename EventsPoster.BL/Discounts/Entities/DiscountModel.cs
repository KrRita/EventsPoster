using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Discounts.Entities
{
    public class DiscountModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }

    }
}
