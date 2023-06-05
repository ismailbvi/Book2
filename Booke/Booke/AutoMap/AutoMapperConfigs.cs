using AutoMapper;
using BookStore.Models.Data;
using BookStore.Models.Request;

namespace Booke.AutoMap
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs() 
        {
            CreateMap<AddAuthorRequest, Author>();
        }
    }
}
