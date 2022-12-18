using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.RemoveProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Models;
using Application.Features.Products.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreatedProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            
            CreateMap<Product, RemovedProductDto>().ReverseMap();
            CreateMap<Product, RemoveProductCommand>().ReverseMap();

            CreateMap<Product, UpdatedProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();

            CreateMap<Product, ProductGetByIdDto>().ReverseMap();
        }
    }
}
