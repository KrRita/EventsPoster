using EventsPoster.BL.Admins.Entities;
using EventsPoster.BL.Discounts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Discounts
{
    public interface IDiscountsManager
    {
        DiscountModel CreateDiscount(CreateDiscountModel model);
        void DeleteDiscount(Guid id);
        DiscountModel UpdateDiscount(Guid id, UpdateDiscountModel model);

    }
}
