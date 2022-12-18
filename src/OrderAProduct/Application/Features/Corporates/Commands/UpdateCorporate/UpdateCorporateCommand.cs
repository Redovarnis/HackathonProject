using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Corporates.Commands.UpdateCorporate
{
    public class UpdateCorporateCommand : IRequest<UpdatedCorporateDto>
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public bool OrderState { get; set; }
        public DateTime StartOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }

        public class UpdateCorporateCommandHandler : IRequestHandler<UpdateCorporateCommand, UpdatedCorporateDto>
        {
            private readonly ICorporateRepository _corporateRepository;
            private readonly IMapper _mapper;
            private readonly CorporateBusinessRules _corporateBusinessRules;

            public UpdateCorporateCommandHandler(ICorporateRepository corporateRepository, IMapper mapper,
                CorporateBusinessRules corporateBusinessRules)
            {
                _corporateRepository = corporateRepository;
                _mapper = mapper;
                _corporateBusinessRules = corporateBusinessRules;
            }

            public async Task<UpdatedCorporateDto> Handle(UpdateCorporateCommand request, CancellationToken cancellationToken)
            {
                await _corporateBusinessRules.CorporateNameCanNotBeDuplicatedWhenInserted(request.CorporateName);
                //await _CorporateBusinessRules.ProgrammingLanguageMustExistWhenAddingNewTechnologies(request.ProgrammingLanguageId);

                Corporate mappedCorporate = _mapper.Map<Corporate>(request);
                _corporateBusinessRules.CorporateShouldExistWhenRequested(mappedCorporate);

                Corporate updatedCorporate = await _corporateRepository.UpdateAsync(mappedCorporate);
                UpdatedCorporateDto updatedCorporateDto = _mapper.Map<UpdatedCorporateDto>(updatedCorporate);
                return updatedCorporateDto;
            }
        }
    }
}
