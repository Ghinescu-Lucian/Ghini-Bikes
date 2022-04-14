using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetOrdersByUser
{
    public class GetOrdersByUserQuery : IRequest<IEnumerable<Order>>
    {
        public int UserId { get; set; }
    }
}
