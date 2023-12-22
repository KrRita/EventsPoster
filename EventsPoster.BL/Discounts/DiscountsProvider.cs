using AutoMapper;
using EventsPoster.BL.Admins.Entities;
using EventsPoster.DataAccess.Entities;
using EventsPoster.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.Discounts.Entities;

namespace EventsPoster.BL.Discounts
{
    public class DiscountsProvider : IDiscountsProvider
    {
        private readonly IRepository<DiscountEntity> _discountRepository;
        private readonly IMapper _mapper;

        public DiscountsProvider(IRepository<DiscountEntity> discountsRepository, IMapper mapper)
        {
            _discountRepository = discountsRepository;
            _mapper = mapper;
        }

        public IEnumerable<DiscountModel> GetDiscounts(DiscountModelFilter modelFilter = null)
        {
            var name = modelFilter?.Name;
            var percent = modelFilter?.Percent;

            var discounts = _discountRepository.GetAll(x => (
            (name == null || name == x.Name) &&
            (percent == null || percent == x.Percent)));

            return _mapper.Map<IEnumerable<DiscountModel>>(discounts);
        }

        public DiscountModel GetDiscountInfo(Guid id)
        {
            var discoubnt = _discountRepository.GetById(id);
            if (discoubnt is null)
                throw new ArgumentException("Discount not found.");

            return _mapper.Map<DiscountModel>(discoubnt);
        }

    }
}
