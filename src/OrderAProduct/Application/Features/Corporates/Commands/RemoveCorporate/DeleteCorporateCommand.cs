using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Corporates.Commands.RemoveCorporate
{
    public class RemoveCorporateCommand : IRequest<RemovedCorporateDto>
    {
        public int Id { get; set; }
        public class RemoveCorporateCommandHandler : IRequestHandler<RemoveCorporateCommand, RemovedCorporateDto>
        {
            private readonly ICorporateRepository _corporateRepository;
            private readonly IMapper _mapper;
            private readonly CorporateBusinessRules _corporateBusinessRules;

            public RemoveCorporateCommandHandler(ICorporateRepository corporateRepository, IMapper mapper, CorporateBusinessRules corporateBusinessRules)
            {
                _corporateRepository = corporateRepository;
                _mapper = mapper;
                _corporateBusinessRules = corporateBusinessRules;
            }

            public async Task<RemovedCorporateDto> Handle(RemoveCorporateCommand request, CancellationToken cancellationToken)
            {
                Corporate mappedCorporate = _mapper.Map<Corporate>(request);
                _corporateBusinessRules.CorporateShouldExistWhenRequested(mappedCorporate);

                Corporate removedCorporate = await _corporateRepository.DeleteAsync(mappedCorporate);
                RemovedCorporateDto removedCorporateDto = _mapper.Map<RemovedCorporateDto>(removedCorporate);

                return removedCorporateDto;
            }
        }
    }
}
