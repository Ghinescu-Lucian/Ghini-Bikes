using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Orders.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public List<OrderItem> Items;
        public DateTime Date { get; set; }
        public User User { get; set; }
        public string TelephoneNr { get; set; }
        public string Address { get; set; }
        public Payment Payment { get; set; }
        public Status Status { get; set; }
        public string ShippingMethod { get; set; }

    }
}
