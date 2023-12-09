using AutoMapper;
using EventsPoster.BL.Admins.Entities;
using EventsPoster.Service.Controllers.Entities;

namespace EventsPoster.Service.Mapper
{
    public class AdminsServiceProfile : Profile
    {
        public AdminsServiceProfile()
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
