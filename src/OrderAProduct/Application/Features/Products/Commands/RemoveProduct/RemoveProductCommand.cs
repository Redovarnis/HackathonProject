using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.RemoveProduct
{
    public class RemoveProductCommand : IRequest<RemovedProductDto>
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemovedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public RemoveProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<RemovedProductDto> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
            {
                Product mappedProduct = _mapper.Map<Product>(request);
                await _productBusinessRules.ProductShouldExistWhenRequested(mappedProduct.ProductName);

                Product removedProduct = await _productRepository.DeleteAsync(mappedProduct);
                RemovedProductDto removedProductDto = _mapper.Map<RemovedProductDto>(removedProduct);

                return removedProductDto;
            }
        }
    }
}
