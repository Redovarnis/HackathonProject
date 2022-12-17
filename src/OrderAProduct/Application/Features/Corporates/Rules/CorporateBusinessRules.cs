using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Corporates.Rules
{
    public class CorporateBusinessRules
    {
        private readonly ICorporateRepository _corporateRepository;

        public CorporateBusinessRules(ICorporateRepository corporateRepository)
        {
            _corporateRepository = corporateRepository;
        }

        public async Task CorporateNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Corporate> result = await _corporateRepository.GetListAsync(b => b.CorporateName == name);
            if (result.Items.Any()) throw new BusinessException("Corporate Name exists.");
        }
        //public void CorporateShouldExistWhenRequested(Corporate corporate)
        //{
        //    if (corporate == null) throw new BusinessException("Requested Corporate does not exists.");
        //}

    }
}
