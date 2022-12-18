using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreatedOrderDto>
    {
        public int ProductId { get; set; }
        public int CorporateId { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderDto>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly OrderBusinessRules _orderBusinessRules;

            public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper,
                OrderBusinessRules orderBusinessRules)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _orderBusinessRules = orderBusinessRules;
            }

            public async Task<CreatedOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                await _orderBusinessRules.ProductMustExistWhenAddingNewOrders(request.ProductId);
                await _orderBusinessRules.CorporateMustExistWhenAddingNewOrders(request.CorporateId);
                
                var mappedOrder = _mapper.Map<Order>(request);
                var createdOrder = await _orderRepository.AddAsync(mappedOrder);
                CreatedOrderDto createdOrderDto = _mapper.Map<CreatedOrderDto>(createdOrder);
                return createdOrderDto;
            }
        }
    }
}
