using AutoMapper;
using Domain.Models;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class OrderItemProfile :Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemDto, OrderItem>()
               .ReverseMap();
        }
    }
}
