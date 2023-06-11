using AutoMapper;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;

namespace Gaming_Store.AutoMap
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
            {
                CreateMap<AddGameRequest,Game>();
                CreateMap<UpdateGameRequest, Game>();
            }
        }

    }
