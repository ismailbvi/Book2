using Gaming_Store_Data.Data;
using AutoMapper;
using Gaming_Store_Data.Request;

namespace GamingStore2.AutoMap
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<AddGameRequest, Game>();
        }
    }
}
