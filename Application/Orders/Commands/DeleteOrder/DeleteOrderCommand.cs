using Domain.Models;
using MediatR;


namespace Application.Orders.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
