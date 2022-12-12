using AutoMapper;
using PlateformService.DTOs;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlateformProfile : Profile
    {
        public PlateformProfile()
        {
            CreateMap<Plateform,PlateformReadDTO>().ReverseMap();
            CreateMap<PlateformCreateDTO,Plateform>().ReverseMap();
        }
    }
}