using AutoMapper;
using EventsPoster.BL.Admins.Entities;
using EventsPoster.BL.Discounts.Entities;
using EventsPoster.Service.Controllers.Entities;


namespace EventsPoster.Service.Mapper
{
    public class DiscountsServiceProfile : Profile
    {
        public DiscountsServiceProfile()
        {
            CreateMap<DiscountsFilter, DiscountModelFilter>();
            CreateMap<CreateDiscountRequest, CreateDiscountModel>();
            CreateMap<UpdateDiscountRequest, UpdateDiscountModel>();
        }

    }
}
