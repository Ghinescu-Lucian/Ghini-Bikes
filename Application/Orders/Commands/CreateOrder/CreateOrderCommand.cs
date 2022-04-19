 using Domain.Enums;
using Domain.Models;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public List<OrderItem> Items;
        public DateTime Date { get; set; }
        public User User { get; set; }
        public string TelephoneNr { get; set; }
        public string Address { get; set; }
        public Payment Payment { get; set; }
        public string ShippingMethod { get; set; }
    
    }
}
