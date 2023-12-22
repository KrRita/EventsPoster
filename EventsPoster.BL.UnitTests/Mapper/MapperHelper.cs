using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventsPoster.Service.Mapper;

namespace EventsPoster.BL.UnitTests.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x => 
            {
                x.AddProfile(typeof(AdminsServiceProfile));
                x.AddProfile(typeof(DiscountsServiceProfile));
                x.AddProfile(typeof(EventsServiceProfile));
            });
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
