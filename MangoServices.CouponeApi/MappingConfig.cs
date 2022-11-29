using AutoMapper;
using MangoServices.CouponApi.Models;
using MangoServices.CouponApi.Models.Dto;

namespace MangoServices.CouponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });

            return mappingConfig;
        }

    }
}
