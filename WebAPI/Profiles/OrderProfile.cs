using Application.Orders.Commands.CreateOrderCommand;
using AutoMapper;
using Domain.Models;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, CreateOrderCommand>()
               .ReverseMap();
            CreateMap<OrderDto, Order>()
                .ReverseMap();
        }
    }
}
