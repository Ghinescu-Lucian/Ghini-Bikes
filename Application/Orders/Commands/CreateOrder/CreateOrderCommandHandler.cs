using Domain.Models;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;
        private IBikeRepository _bikeRepository;
        private IAccessoryRepository _accessoryRepository;
        private IPartRepository _partRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IBikeRepository bikeRepository,
                                         IAccessoryRepository accessoryRepository, IPartRepository partRepository)
        {
            _orderRepository = orderRepository;
            _bikeRepository = bikeRepository;
            _accessoryRepository = accessoryRepository;
            _partRepository = partRepository;
        }

        public Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            double total = 0;

            /*var items = new List<OrderItem>();
            if (request.Items != null)
            {
                foreach (var item in request.Items)
                {
                    
                    if (item._Product.Category <= 3)
                    {
                        var bike = _bikeRepository.GetBikeById(item._Product.ProductId);
                        var orderItem = new OrderItem { _Product = bike, Quantity = item.Quantity, Discount = item.Discount };
                        items.Add(orderItem);
                    }
                    else if (item._Product.Category == 4)
                    {
                        var part = _partRepository.GetPartById(item._Product.ProductId);
                        var orderItem = new OrderItem { _Product = part, Quantity = item.Quantity, Discount = item.Discount };
                        items.Add(orderItem);
                    }
                    else
                    {
                        var accessory = _accessoryRepository.GetAccessoryById(item._Product.ProductId);
                        var orderItem = new OrderItem { _Product = accessory, Quantity = item.Quantity, Discount = item.Discount };
                        items.Add(orderItem);
                    }
                }
            }
            */
            foreach (OrderItem item in request.Items)
            {
                total += item._Product.Price * (100 - item.Discount) / 100 * item.Quantity;
            }

            ShippingCostContext shippingContext = new ShippingCostContext();
            if (string.Equals(request.ShippingMethod, "Personal"))
                shippingContext.SetStrategy(new PesonalLiftShippingCost());
            else shippingContext.SetStrategy(new CourierShippingCost() { OrderPrice = total });


            var order = new Order()// request.Items, request.User, request.ShippingMethod)
            {
                Items = request.Items,
                UserId = request.UserId,
                Date = DateTime.Now,
                TotalCost = total,
                FinalCost = total + shippingContext.CalculateShippingCost(),
                ShippingCost = shippingContext,
                TelephoneNr = request.TelephoneNr,
                Address = request.Address,
                Pay = request.Payment,
                Name = request.Name
            };
            _orderRepository.CreateOrder(order);
            return Task.FromResult(order);
        }
    }
}
