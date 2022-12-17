using AutoMapper;
using MediatR;
using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Rules;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Corporates.Queries.GetByIdCorporate
{
    public class GetByIdCorporateQuery : IRequest<CorporateGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdCorporateQueryHandler : IRequestHandler<GetByIdCorporateQuery, CorporateGetByIdDto>
        {
            private readonly ICorporateRepository _corporateRepository;
            private readonly IMapper _mapper;
            private readonly CorporateBusinessRules _corporateBusinessRules;

            public GetByIdCorporateQueryHandler(ICorporateRepository corporateRepository, IMapper mapper, CorporateBusinessRules corporateBusinessRules)
            {
                _corporateRepository = corporateRepository;
                _mapper = mapper;
                _corporateBusinessRules = corporateBusinessRules;
            }

            public async Task<CorporateGetByIdDto> Handle(GetByIdCorporateQuery request, CancellationToken cancellationToken)
            {
                Corporate? corporate = await _corporateRepository.GetAsync(b => b.Id == request.Id);
                _corporateBusinessRules.CorporateShouldExistWhenRequested(corporate);

                CorporateGetByIdDto corporateGetByIdDto = _mapper.Map<CorporateGetByIdDto>(corporate);
                return corporateGetByIdDto;
            }
        }
    }
}
