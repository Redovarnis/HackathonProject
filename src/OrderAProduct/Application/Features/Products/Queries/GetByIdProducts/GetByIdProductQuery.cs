using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;

namespace Application.Features.Products.Queries.GetByIdProducts
{
    public class GetByIdProductQuery : IRequest<ProductGetByIdDto>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductGetByIdDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<ProductGetByIdDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(b => b.Id == request.Id);
                await _productBusinessRules.ProductShouldExistWhenRequested(product.ProductName);

                ProductGetByIdDto productGetByIdDto = _mapper.Map<ProductGetByIdDto>(product);
                return productGetByIdDto;
            }
        }
    }
}
