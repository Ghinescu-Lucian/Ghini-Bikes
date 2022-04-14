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
            Console.WriteLine("AIci");
            _db.Users.SingleOrDefault(u => u.Id == order.User.Id).Orders.Add(order);
           // _db.Add(order);
            _db.SaveChanges();
        }

        public Order DeleteOrder(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var orderDelete = _db.Orders.Single(o => o.Id == orderId);
            _db.Remove(orderDelete);
            _db.SaveChanges();
            return orderDelete;

        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders.Include( o => o.Items);
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            return _db.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetOrdersByUser(int userId)
        {
            if (userId == null || userId<=0 ) throw new ArgumentNullException("user parameter is null");
            var result = _db.Orders.Where(o => o.User.Id == userId);
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
                    o.User = order.User;
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
