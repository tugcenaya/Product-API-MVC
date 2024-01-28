using AutoMapper;
using Project.API.Models.Products;
using Project.API.Models.Products.DTOs;

namespace Project.API.Mapping;
public class DtoProfile : Profile
{
    public DtoProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}