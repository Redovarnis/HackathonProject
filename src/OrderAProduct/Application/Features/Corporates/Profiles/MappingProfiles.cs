using AutoMapper;
using Application.Features.Corporates.Commands.CreateCorporate;
using Application.Features.Corporates.Dtos;
using Domain.Entities;

namespace Application.Features.Corporates.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Corporate, CreatedCorporateDto>().ReverseMap();
            CreateMap<Corporate, CreateCorporateCommand>().ReverseMap();
        }
    }
}
