using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapper()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                //config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }


    }
}
