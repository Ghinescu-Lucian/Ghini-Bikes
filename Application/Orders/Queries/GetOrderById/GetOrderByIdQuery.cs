using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
