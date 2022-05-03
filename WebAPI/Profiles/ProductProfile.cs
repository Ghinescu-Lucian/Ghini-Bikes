using AutoMapper;
using Domain.Models;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
               .ReverseMap();
        }
    }
}
