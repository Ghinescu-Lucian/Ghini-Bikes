using Domain.Models;
using MediatR;

namespace Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.GetOrderById(request.Id);
            return Task.FromResult(order);
        }
    }
}
