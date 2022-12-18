using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreatedOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();

            CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
        }
    }
}
