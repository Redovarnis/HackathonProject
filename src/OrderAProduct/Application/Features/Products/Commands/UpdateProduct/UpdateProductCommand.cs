using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdatedProductDto>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CorporateName { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper,
                ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinessRules.CorporateMustExistWhenAddingNewProducts(request.CorporateName);

                Product mappedProduct = _mapper.Map<Product>(request);
                await _productBusinessRules.ProductShouldExistWhenRequested(mappedProduct.ProductName);

                Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
                UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(updatedProduct);
                return updatedProductDto;
            }
        }
    }
}
