using Domain.Models;
using MediatR;

namespace Application.Orders.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()//request.Items, request.User, request.ShippingMethod)
            {
                
                Status = request.Status,
                Message = request.Message,
              
            };
            _orderRepository.UpdateOrder(request.Id, order);
            return Task.FromResult(order);
        }
    }
}
