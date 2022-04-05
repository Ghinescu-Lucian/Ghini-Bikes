using Application;
using Domain.Models;

namespace Infrastructure
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private List<Order> _orders= new();
        public void CreateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException("order parameter is null");
            order.Id = _orders.Count + 1;
            _orders.Add(order);
        }

        public Order DeleteOrder(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var orderDelete = _orders.Single( o => o.Id == orderId);
            _orders.Remove(orderDelete);
            return orderDelete;

        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            return _orders.FirstOrDefault( o => o.Id == orderId);
        }

        public IEnumerable<Order> GetOrdersByUser(User user)
        {
            if(user == null) throw new ArgumentNullException("user parameter is null");
            var result = _orders.Where(o => string.Equals(o.User.Username, user.Username));
            return result;
        }

        public void UpdateOrder(int orderId, Order order)
        {
            if(orderId < 0) throw new ArgumentOutOfRangeException("Invalid order Id ( <0 )" + orderId);
            if(order == null) throw new ArgumentNullException("order parameter is null");
            int ok = 0;
            foreach (Order o in _orders)
                if (o.Id == orderId)
                {
                    ok = ok + 1;
                    o.Address = order.Address;
                    o.User =  order.User;
                    o.ShippingCost = order.ShippingCost;
                    o.TotalCost = order.TotalCost;
                    o.Date = order.Date;
                    o.TelephoneNr = order.TelephoneNr;
                    o.Pay = order.Pay;
                    o.Status = order.Status;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid order Id");
        }

    }
}
