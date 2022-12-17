using AutoMapper;
using Application.Features.Corporates.Commands.CreateCorporate;
using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Models;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Corporates.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Corporate, CreatedCorporateDto>().ReverseMap();
            CreateMap<Corporate, CreateCorporateCommand>().ReverseMap();

            CreateMap<IPaginate<Corporate>, CorporateListModel>().ReverseMap();
            CreateMap<Corporate, CorporateListDto>().ReverseMap();

            CreateMap<Corporate, CorporateGetByIdDto>();
        }
    }
}
