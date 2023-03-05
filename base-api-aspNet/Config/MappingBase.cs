using AutoMapper;
using base_api_aspNet.Models;
using base_api_aspNet.Models.Dtos;

namespace base_api_aspNet.Config
{
    public class MappingBase : Profile
    {
        public MappingBase()
        {
            CreateMap<Base, BaseDto>();
        }
    }
}
