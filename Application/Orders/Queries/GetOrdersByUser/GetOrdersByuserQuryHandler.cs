using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetOrdersByUser
{
    public class GetOrdersByuserQuryHandler : IRequestHandler<GetOrdersByUserQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByuserQuryHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<IEnumerable<Order>> Handle(GetOrdersByUserQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetOrdersByUser(request.User);
            return Task.FromResult(orders);
        }
    }
}
