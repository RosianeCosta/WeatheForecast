using AutoMapper;
using Weather.Domain;
using Weather.WebApi.Dtos;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles(){
      
            CreateMap<CitiesDto, Cities>();
            CreateMap<Cities, CitiesDto>();
       }
    }
}