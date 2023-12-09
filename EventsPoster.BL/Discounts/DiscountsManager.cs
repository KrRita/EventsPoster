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
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EventsPoster.BL.Discounts
{
    public class DiscountsManager : IDiscountsManager
    {
        private readonly IRepository<DiscountEntity> _discountsRepository;
        private readonly IMapper _mapper;
        public DiscountsManager(IRepository<DiscountEntity> discountsRepository, IMapper mapper)
        {
            _discountsRepository = discountsRepository;
            _mapper = mapper;
        }

        public DiscountModel CreateDiscount(CreateDiscountModel model)
        {
            var entity = _mapper.Map<DiscountEntity>(model);

            _discountsRepository.Save(entity); //id, modification, externalId

            return _mapper.Map<DiscountModel>(entity);
        }
        public void DeleteDiscount(Guid id)
        {
            var entity = _discountsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Discount not found");
            _discountsRepository.Delete(entity);
        }
        public DiscountModel UpdateDiscount(Guid id, UpdateDiscountModel model)
        {
            //validate data
            var entity = _discountsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Discount not found");
            entity.Name = model.Name;
            entity.Percent = model.Percent;
            _discountsRepository.Save(entity);
            return _mapper.Map<DiscountModel>(entity);
        }

    }
}
