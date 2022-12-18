using AutoMapper;
using Application.Features.Corporates.Commands.CreateCorporate;
using Application.Features.Corporates.Commands.RemoveCorporate;
using Application.Features.Corporates.Commands.UpdateCorporate;
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

            CreateMap<Corporate, RemovedCorporateDto>().ReverseMap();
            CreateMap<Corporate, RemoveCorporateCommand>().ReverseMap();

            CreateMap<Corporate, UpdatedCorporateDto>().ReverseMap();
            CreateMap<Corporate, UpdateCorporateCommand>().ReverseMap();

            CreateMap<IPaginate<Corporate>, CorporateListModel>().ReverseMap();
            CreateMap<Corporate, CorporateListDto>().ReverseMap();

            CreateMap<Corporate, CorporateGetByIdDto>();
        }
    }
}
