using Domain.Models;
using MediatR;

namespace Application.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.products, request.User, request.ShippingMethod)
            {
                Date = request.Date,
                TelephoneNr = request.TelephoneNr,
                Address = request.Address,
                Pay = request.Payment
            };
            _orderRepository.CreateOrder(order);
            return Task.FromResult(order);
        }
    }
}
