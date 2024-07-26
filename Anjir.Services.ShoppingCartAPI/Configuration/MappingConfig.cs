
using Anjir.Services.ShoppingCartAPI.Models.Dto;
using Anjir.Services.ShoppingCartAPI.Models;
using AutoMapper;

namespace Anjir.Services.ShoppingCartAPI.Configuration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
        }
    }
}
