using AutoMapper;


namespace Mango.Services.OrderAPI.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapper()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                //config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }


    }
}
