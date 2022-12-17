using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Corporates.Commands.CreateCorporate
{
    public class CreateCorporateCommand : IRequest<CreatedCorporateDto>
    {
        public string CorporateName { get; set; }
        public bool OrderState { get; set; }
        public DateTime StartOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }

        public class CreateCorporateCommandHandler : IRequestHandler<CreateCorporateCommand, CreatedCorporateDto>
        {
            private readonly ICorporateRepository _corporateRepository;
            private readonly IMapper _mapper;
            private readonly CorporateBusinessRules _corporateBusinessRules;

            public CreateCorporateCommandHandler(ICorporateRepository corporateRepository, IMapper mapper,
                CorporateBusinessRules corporateBusinessRules)
            {
                _corporateRepository = corporateRepository;
                _mapper = mapper;
                _corporateBusinessRules = corporateBusinessRules;
            }

            public async Task<CreatedCorporateDto> Handle(CreateCorporateCommand request, CancellationToken cancellationToken)
            {
                await _corporateBusinessRules.CorporateNameCanNotBeDuplicatedWhenInserted(request.CorporateName);

                Corporate mappedCorporate = _mapper.Map<Corporate>(request);
                Corporate createdCorporate = await _corporateRepository.AddAsync(mappedCorporate);
                CreatedCorporateDto createdCorporateDto = _mapper.Map<CreatedCorporateDto>(createdCorporate);
                return createdCorporateDto;
            }
        }
    }
}
