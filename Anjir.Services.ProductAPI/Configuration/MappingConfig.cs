
using Anjir.Services.ProductAPI.Models;
using Anjir.Services.ProductAPI.Models.Dto;
using AutoMapper;

namespace Anjir.Services.ProductAPI.Configuration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>();
            });
        }
    }
}
