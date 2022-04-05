using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetOrdersByUser
{
    public class GetOrdersByUserQuery : IRequest<IEnumerable<Order>>
    {
        public User User { get; set; }
    }
}
