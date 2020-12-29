using AutoMapper;
using Routine.API.Entities;
using Routine.API.Models;

namespace Routine.API.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name));
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyFullDto>();

        }
    }
}