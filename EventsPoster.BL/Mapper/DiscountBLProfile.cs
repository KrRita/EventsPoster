using AutoMapper;
using EventsPoster.BL.Discounts.Entities;
using EventsPoster.DataAccess.Entities;


namespace EventsPoster.BL.Mapper
{
    public class DiscountBLProfile : Profile
    {
        public DiscountBLProfile()
        {
            CreateMap<DiscountEntity, DiscountModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateDiscountModel, DiscountEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Tickets, y => y.Ignore());
        }

    }
}
