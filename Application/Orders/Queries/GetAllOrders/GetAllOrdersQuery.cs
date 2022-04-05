using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
