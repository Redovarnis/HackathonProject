using Core.CrossCuttingConcerns.Exceptions;
using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly ICorporateRepository _corporateRepository;

        public ProductBusinessRules(IProductRepository productRepository, ICorporateRepository corporateRepository)
        {
            _productRepository = productRepository;
            _corporateRepository = corporateRepository;
        }

        public async Task CorporateMustExistWhenAddingNewProducts(string corporateName)
        {
            var result = await _corporateRepository.GetAsync(x => x.CorporateName.Equals(corporateName));
            if (result == null) throw new BusinessException("Requested Product does not exists.");
        }

        public async Task ProductShouldExistWhenRequested(string productName)
        {
            IPaginate<Product> result = await _productRepository.GetListAsync(b => b.CorporateName.Equals(productName));
            if (result.Items.Any() == null) throw new BusinessException("Requested Product does not exists.");
        }

    }
}
