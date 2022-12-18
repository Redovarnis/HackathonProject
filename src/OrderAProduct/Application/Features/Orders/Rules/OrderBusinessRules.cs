using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Orders.Rules
{
    public class OrderBusinessRules
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICorporateRepository _corporateRepository;
        private readonly IProductRepository _productRepository;

        public OrderBusinessRules(IOrderRepository orderRepository, ICorporateRepository corporateRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _corporateRepository = corporateRepository;
            _productRepository = productRepository;
        }

        public async Task ProductMustExistWhenAddingNewOrders(int productId)
        {
            var result = await _productRepository.GetAsync(x => x.Id == productId);
            if (result == null) throw new BusinessException("Product does not exists");
        }

        public async Task CorporateMustExistWhenAddingNewOrders(int corporateId)
        {
            var result = await _corporateRepository.GetAsync(x => x.Id == corporateId);
            if (result == null) throw new BusinessException("Corporate does not exists");
        }


    }
}
