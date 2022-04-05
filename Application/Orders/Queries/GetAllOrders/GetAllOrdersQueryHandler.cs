using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAllOrders();
            return Task.FromResult(orders);
        }
    }
}
