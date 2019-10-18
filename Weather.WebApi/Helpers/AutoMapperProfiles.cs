using AutoMapper;
using Weather.Domain;
using Weather.WebApi.Dtos;

namespace Weather.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
  
            CreateMap<Cities, CitiesDto>();

            CreateMap<CitiesDto, Cities>();
        }
    }
}