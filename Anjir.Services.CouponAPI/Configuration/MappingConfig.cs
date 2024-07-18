using Anjir.Services.CouponAPI.Models;
using Anjir.Services.CouponAPI.Models.Dto;
using AutoMapper;

namespace Anjir.Services.CouponAPI.Configuration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>();
                config.CreateMap<CouponDto, Coupon>();
            });
        }
    }
}
