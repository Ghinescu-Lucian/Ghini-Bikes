using Domain.Models;
using Domain.Orders;
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
            ShippingCostContext shippingContext = new ShippingCostContext();
            if (string.Equals(request.ShippingMethod, "Personal"))
                 shippingContext.SetStrategy(new PesonalLiftShippingCost());
            else shippingContext.SetStrategy(new CourierShippingCost());
            var order = new Order()// request.Items, request.User, request.ShippingMethod)
            {
                Items = request.Items,
                User = request.User,
                Date = request.Date,
                ShippingCost = shippingContext,
                TelephoneNr = request.TelephoneNr,
                Address = request.Address,
                Pay = request.Payment
            };
            _orderRepository.CreateOrder(order);
            return Task.FromResult(order);
        }
    }
}
