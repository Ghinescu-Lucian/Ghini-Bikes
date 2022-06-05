using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Orders.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        
        public Status Status { get; set; }

        public string Message { get; set; }
        

    }
}
