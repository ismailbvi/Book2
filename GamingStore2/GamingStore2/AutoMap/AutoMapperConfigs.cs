using Gaming_Store_Data.Data;
using AutoMapper;
using Gaming_Store_Data.GameDto;

namespace GamingStore2.AutoMap
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs() 
        {
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<CreateGameDto, Game>();
            CreateMap<UpdateGameDto, Game>();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
