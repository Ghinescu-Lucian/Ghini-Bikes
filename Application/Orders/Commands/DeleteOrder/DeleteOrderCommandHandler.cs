using Domain.Models;
using MediatR;

namespace Application.Orders.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<Order> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.DeleteOrder(request.Id);
            return Task.FromResult(order);
        }
    }
}
