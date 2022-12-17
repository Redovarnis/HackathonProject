using Application.Features.Corporates.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Corporates.Commands.CreateCorporate
{
    public class CreateCorporateCommand : IRequest<CreatedCorporateDto>
    {
        public string CorporateName { get; set; }
        public class CreateCorporateCommandHandler : IRequestHandler<CreateCorporateCommand, CreatedCorporateDto>
        {
            private readonly ICorporateRepository _CorporateRepository;
            private readonly IMapper _mapper;

            public CreateCorporateCommandHandler(ICorporateRepository CorporateRepository, IMapper mapper/*,
                CorporateBusinessRules CorporateBusinessRules*/)
            {
                _CorporateRepository = CorporateRepository;
                _mapper = mapper;
                //_CorporateBusinessRules = CorporateBusinessRules;
            }

            public async Task<CreatedCorporateDto> Handle(CreateCorporateCommand request, CancellationToken cancellationToken)
            {
                //await _CorporateBusinessRules.CorporateNameCanNotBeDuplicatedWhenInserted(request.CorporateName);

                Corporate mappedCorporate = _mapper.Map<Corporate>(request);
                Corporate createdCorporate = await _CorporateRepository.AddAsync(mappedCorporate);
                CreatedCorporateDto createdCorporateDto = _mapper.Map<CreatedCorporateDto>(createdCorporate);
                return createdCorporateDto;
            }
        }
    }
}
