using Application;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _db;
        public OrderRepository(ShopDbContext db) { _db = db; }
        public void CreateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException("order parameter is null");
            //Console.WriteLine("AIci");
            _db.Users.SingleOrDefault(u => u.Id == order.UserId).Orders.Add(order);
            //_db.Add(order);
            _db.SaveChanges();
        }

        public Order DeleteOrder(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var orderDelete = _db.Orders.Single(o => o.Id == orderId);
            foreach (OrderItem oi in orderDelete.Items)
                _db.Remove(orderDelete);
            _db.SaveChanges();
            return orderDelete;

        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _db.Orders.Include(i => i.Items);
            foreach(Order o in orders)
            {
                foreach (OrderItem oi in o.Items)
                    oi.Order = null;
            }
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var order = _db.Orders.Include(i => i.Items).SingleOrDefault(i => i.Id == orderId);
            foreach (OrderItem oi in order.Items)
            {
                oi.Order = null;
            }
            return order;
        }

        public IEnumerable<Order> GetOrdersByUser(int userId)
        {
            if (userId == null || userId <= 0) throw new ArgumentNullException("user parameter is null");
            var result = _db.Orders.Where(o => o.UserId == userId);
            return result;
        }

        public void UpdateOrder(int orderId, Order order)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException("Invalid order Id ( <0 )" + orderId);
            if (order == null) throw new ArgumentNullException("order parameter is null");
            int ok = 0;
            foreach (Order o in _db.Orders)
                if (o.Id == orderId)
                {
                    ok = ok + 1;
                    o.Address = order.Address;
                    // o.UserId = order.UserId;
                    o.ShippingCost = order.ShippingCost;
                    o.TotalCost = order.TotalCost;
                    o.Date = order.Date;
                    o.TelephoneNr = order.TelephoneNr;
                    o.Pay = order.Pay;
                    o.Status = order.Status;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid order Id");
            _db.SaveChanges();
        }
    }
}
